using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Heç bir kateqoriya tapılmadı";
                return "Bu cür kateqoriya tapılmadı";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kateqoriya uğurla əlavə edildi.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kateqoriya uğurla silindi.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kateqoriya uğurla databazadan silindi.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kateqoriya uğurla yeniləndi";
            }
        }
        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Heç bir məqalə tapılmadı";
                return "Bu cür məqalə tapılmadı";
            }
            public static string Add(string articleName)
            {
                return $"{articleName} adlı məqalə uğurla əlavə edildi.";
            }
            public static string Delete(string articleName)
            {
                return $"{articleName} adlı məqalə uğurla silindi.";
            }
            public static string HardDelete(string articleName)
            {
                return $"{articleName} adlı məqalə uğurla databazadan silindi.";
            }
            public static string Update(string articleName)
            {
                return $"{articleName} adlı məqalə uğurla yeniləndi";
            }
        }
    }
}
