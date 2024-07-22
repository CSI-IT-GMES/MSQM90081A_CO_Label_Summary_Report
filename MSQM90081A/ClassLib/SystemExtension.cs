using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace System {
    public static class SystemExtension {
        #region String
        public static string ToArrayString(this string[] array) {
            string text = null;

            foreach (string item in array) {
                text += $"{(text == null ? "" : ",")}{item}";
            }
            return text;
        }

        public static string ToListString(this List<string> list) {
            string text = null;

            if (list == null) return text;

            foreach (string item in list) {
                text += $"{(text == null ? "" : ",")}{item}";
            }
            return text;
        }

        public static string ToBoolString(this bool value) {
            return value ? "1" : "0";
        }

        public static string ToStringEmpty(this object value) {
            try {
                return value.ToString();
            } catch {
                return "";
            }
        }

        #endregion String

        #region Number

        public static int? ToIntNull(this object value) {
            try {
                if (string.IsNullOrEmpty(value.ToString())) {
                    return null;
                } else {
                    return (int?)Convert.ToInt32(value.ToString().Replace(",", ""));
                }
            } catch {
                return null;
            }
        }

        public static double? ToDoubleNull(this object value) {
            try {
                if (string.IsNullOrEmpty(value.ToString())) {
                    return null;
                } else {
                    return Convert.ToDouble(value.ToString().Replace(",", ""));
                }
            } catch {
                return null;
            }
        }

        public static int ToInt(this object value) {
            try {
                if (string.IsNullOrEmpty(value.ToString())) {
                    return (int)0;
                } else {
                    return Convert.ToInt32(value.ToString().Replace(",", ""));
                }
            } catch {
                return (int)0;
            }
        }

        public static double ToDouble(this object value) {
            try {
                if (string.IsNullOrEmpty(value.ToString())) {
                    return (double)0;
                } else {
                    return Convert.ToDouble(value.ToString().Replace(",", ""));
                }
            } catch {
                return (double)0;
            }
        }

        #endregion Number

        #region Color
        public static Color ToColor(this string colorString) {
            if (colorString == null) return Color.FromName("");
            // if it's a hex color
            if (colorString.StartsWith("#")) {
                return ColorTranslator.FromHtml(colorString);
            }

            // if it's a hex int color
            if (colorString.StartsWith("0x")) {
                int hexInt = Convert.ToInt32(colorString, 16);
                return Color.FromArgb((hexInt >> 16) & 0xFF, (hexInt >> 8) & 0xFF, hexInt & 0xFF);
            }

            // if it's a RGB color
            if (colorString.Contains(",")) {
                string[] components = colorString.Split(',');
                if (components.Length == 3 &&
                    byte.TryParse(components[0], out byte red) &&
                    byte.TryParse(components[1], out byte green) &&
                    byte.TryParse(components[2], out byte blue)) {
                    return Color.FromArgb(red, green, blue);
                }
            }

            return Color.FromName(colorString);
        }

        public static Color ToForeColor(this Color backgroundColor) {
            // Determine the luminance of the background color
            double luminance = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            // Choose a threshold for luminance to determine if the text should be black or white
            double threshold = 0.7;
            // Set text color based on the background luminance
            return luminance > threshold ? Color.Black : Color.White;
        }

        public static Color ToForeColor(this string colorString) {
            Color backgroundColor = ToColor(colorString);
            // Determine the luminance of the background color
            double luminance = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            // Choose a threshold for luminance to determine if the text should be black or white
            double threshold = 0.7;
            // Set text color based on the background luminance
            return luminance > threshold ? Color.Black : Color.White;
        }

        #endregion Color

        #region Datetime
        public static DateTime TodayFirstTime(this DateTime dt) {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
        }

        public static DateTime TodayLastTime(this DateTime dt) {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        public static DateTime FirstDayOfMonth(this DateTime datetime) {
            return new DateTime(datetime.Year, datetime.Month, (int)1);
        }

        public static DateTime LastDayOfMonth(this DateTime datetime) {
            return datetime.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfYear(this DateTime datetime) {
            return new DateTime(datetime.Year, (int)1, (int)1);
        }

        public static DateTime LastDayOfYear(this DateTime datetime) {
            return new DateTime(datetime.Year, (int)12, (int)31);
        }

        public static DateTime LastDayOfMaxYear(this DateTime datetime) {
            return new DateTime((int)2099, (int)12, (int)31);
        }
        #endregion Datetime

        #region To List
        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new() {
            var dataList = new List<TSource>();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo p in typeof(TSource).GetProperties(flags)
                                 select new {
                                     Name = p.Name,
                                     Type = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType
                                 }).ToList();
            var dtFieldNames = (from DataColumn c in dataTable.Columns
                                select new {
                                    Name = c.ColumnName,
                                    Type = c.DataType
                                }).ToList();
            var commonFields = (from o in objFieldNames
                                join d in dtFieldNames on new { o.Name } equals new { d.Name }
                                select new {
                                    Name = o.Name,
                                    Type = o.Type
                                }).ToList();
            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList()) {
                var aTSource = new TSource();
                foreach (var f in commonFields) {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(f.Name);
                    try {

                        if (dataRow[f.Name] == DBNull.Value || propertyInfos.PropertyType == dataRow[f.Name].GetType()) {
                            var value = (dataRow[f.Name] == DBNull.Value) ? null : dataRow[f.Name];
                            propertyInfos.SetValue(aTSource, value, null);
                        } else {
                            #region SetValue

                            if (propertyInfos.PropertyType == typeof(Boolean) && dataRow[f.Name].GetType() == typeof(String)) {
                                propertyInfos.SetValue(aTSource, (dataRow[f.Name].ToString() == "1"), null);
                            } else if (propertyInfos.PropertyType == typeof(Int16?)) {
                                propertyInfos.SetValue(aTSource, (Int16?)Convert.ChangeType(dataRow[f.Name], typeof(Int16)), null);
                            } else if (propertyInfos.PropertyType == typeof(Int32?)) {
                                propertyInfos.SetValue(aTSource, (Int32?)Convert.ChangeType(dataRow[f.Name], typeof(Int32)), null);
                            } else if (propertyInfos.PropertyType == typeof(Int64?)) {
                                propertyInfos.SetValue(aTSource, (Int64?)Convert.ChangeType(dataRow[f.Name], typeof(Int64)), null);
                            } else if (propertyInfos.PropertyType == typeof(Double?)) {
                                propertyInfos.SetValue(aTSource, (Double?)Convert.ChangeType(dataRow[f.Name], typeof(Double)), null);
                            } else if (propertyInfos.PropertyType == typeof(Decimal?)) {
                                propertyInfos.SetValue(aTSource, (Decimal?)Convert.ChangeType(dataRow[f.Name], typeof(Decimal)), null);
                            } else {
                                propertyInfos.SetValue(aTSource, dataRow[f.Name], null);
                            }

                            #endregion
                        }
                    } catch (Exception ex) {
                        Debug.WriteLine($"ToList ({dataRow[f.Name]}): " + ex.Message);
                    }

                }
                dataList.Add(aTSource);
            }
            return dataList;
        }
        public static List<string> ToStringList(this string text) {
            List<string> list = new List<string>();

            if (text == null) return list;

            foreach (string item in text.Split(',')) {
                list.Add(item);
            }
            return list;
        }
        #endregion To List

        #region Datatable
        public static DataTable ToDataTable(this List<object> list) {
            DataTable dataTable = new DataTable();

            // Add columns to DataTable
            if (list.Count > 0) {
                foreach (var prop in list[0].GetType().GetProperties()) {
                    dataTable.Columns.Add(prop.Name, prop.PropertyType);
                }

                foreach (var obj in list) {
                    DataRow row = dataTable.NewRow();
                    foreach (var prop in obj.GetType().GetProperties()) {
                        row[prop.Name] = prop.GetValue(obj);
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        public static DataTable GetParamInfo(this List<object> list) {
            DataTable dataTable = new DataTable();

            // Add columns to DataTable
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("type", typeof(string));
            dataTable.Columns.Add("size", typeof(string));
            dataTable.Columns.Add("direction", typeof(string));

            // Add columns to DataTable
            if (list.Count > 0) {
                foreach (var prop in list[0].GetType().GetProperties()) {
                    string name = prop.Name;
                    string type = "Varchar2";
                    string size = "0";
                    string direction = "Input";

                    DataRow row = dataTable.NewRow();
                    row["name"] = name;
                    row["type"] = type;
                    row["size"] = size;
                    row["direction"] = direction;
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
        #endregion Datatable

        #region Vietnamese Sign
        public static string RemoveSign(this string text) {
            string[] arr1 = new string[] {
                "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] {
                "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                "d",
                "e","e","e","e","e","e","e","e","e","e","e",
                "i","i","i","i","i",
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                "u","u","u","u","u","u","u","u","u","u","u",
                "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++) {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        #endregion Vietnamse Sign

        #region Decode Encode Base64
        public static string EncodeBase64(this string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string DecodeBase64(this string base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
       

        #endregion Decode Encode Base64
    }
}