using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Service.Utils
{
    public static class StringUtils
    {
        public static string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public static string GenerateSaltedHash(string plainText, string salt)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var plainTextWithSaltBytes = new List<byte>(plainTextBytes.Length + saltBytes.Length);
            plainTextWithSaltBytes.AddRange(plainTextBytes);
            plainTextWithSaltBytes.AddRange(saltBytes);

            HashAlgorithm algorithm = new SHA256Managed();
            var byteHash = algorithm.ComputeHash(plainTextWithSaltBytes.ToArray());
            return Convert.ToBase64String(byteHash);
        }

        public static string GenerateSlug(string stringToSlug, IEnumerable<BaseEntity> similarList, string previousSlug)
        {
            var slug = CreateUrl(stringToSlug, "-");

            var matchingEntities = similarList.ToList();

            if (!matchingEntities.Any())
            {
                return slug;
            }

            if (string.IsNullOrEmpty(previousSlug))
            {
                if (matchingEntities.Any())
                {
                    slug = string.Concat(slug, "-", matchingEntities.Count);
                }
            }
            else
            {
                if (slug != previousSlug)
                {
                    if (matchingEntities.Any())
                    {
                        slug = string.Concat(slug, "-", matchingEntities.Count);
                    }
                }
            }

            return slug;
        }

        public static string CreateUrl(string strInput, string replaceWith)
        {
            strInput = HttpUtility.HtmlDecode(strInput);

            var url = RemoveAccents(strInput);
            return StripNonAlphaNumeric(url, replaceWith).ToLower();
        }

        public static string RemoveAccents(string input)
        {
            var stringFromD = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var t in stringFromD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string StripNonAlphaNumeric(string strInput, string replaceWith)
        {
            strInput = Regex.Replace(strInput, "[^\\w]", replaceWith);
            strInput = strInput.Replace(string.Concat(replaceWith, replaceWith, replaceWith), replaceWith)
                                .Replace(string.Concat(replaceWith, replaceWith), replaceWith)
                                .TrimStart(Convert.ToChar(replaceWith))
                                .TrimEnd(Convert.ToChar(replaceWith));
            return strInput;
        }
    }
}