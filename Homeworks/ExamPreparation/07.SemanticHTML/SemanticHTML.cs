using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.SemanticHTML
{
    class SemanticHTML
    {
        static void Main(string[] args)
        {
            List<string> tags = new List<string>();
            string tagRow = Console.ReadLine();

            while (tagRow.ToLower() != "end")
            {
                tags.Add(tagRow);
                tagRow = Console.ReadLine();
            }

            string semanticHtmlPattern = @"(?<tag>div)(?:.*)(id|class)(\s*=\s*"")(?<semantic>\w+)("".*)";
            Regex semanticHtmlRegex = new Regex(semanticHtmlPattern);

            string closeTagPattern = @"(?<closeTag>div)(?:>\s*<!--\s*)(?<comment>\w+)\s*-->";
            Regex closeTagRegex = new Regex(closeTagPattern);

            string commentPattern = @"(?:<!--\s?)(\w+)(\s?-->)";
            Regex commentRegex = new Regex(commentPattern);

            string idOrClassPattern = @"([^(pulli)])(?:.*)(id|class)(\s*=\s*"")(\w+)(""\s*)*";
            Regex idOrClassRegex = new Regex(idOrClassPattern);

            //string divPattern = "div";
            //Regex divRegex = new Regex(divPattern);

            //string spacesInTheEndPattern = @"\s+>";
            //Regex spacesInTheEndRegex = new Regex(spacesInTheEndPattern);

            //string multipleSpacesPattern = @"\s{2,}";
            //Regex multipleSpacesRegex = new Regex(multipleSpacesPattern);

            

            for (int i = 0; i < tags.Count; i++)
            {
                if (semanticHtmlRegex.IsMatch(tags[i]))
                {
                    string tag = semanticHtmlRegex.Match(tags[i]).Groups["tag"].ToString();
                    string semantic = semanticHtmlRegex.Match(tags[i]).Groups["semantic"].ToString();
                    //Console.WriteLine(tag + "\n " + semantic);
                    tags[i] = Regex.Replace(tags[i], @"div", semantic);
                    tags[i] = Regex.Replace(tags[i], @"(id|class)(\s*=\s*"")(?<semantic>\w+)*(""\s*)", "");
                }

                if (idOrClassRegex.IsMatch(tags[i]))
                {
                    Console.WriteLine();
                    tags[i] = Regex.Replace(tags[i], @"(id|class)(\s*=\s*"")(\w+)(""\s*)", "");
                }

                if (closeTagRegex.IsMatch(tags[i]))
                {
                    string comment = closeTagRegex.Match(tags[i]).Groups["comment"].ToString();
                    tags[i] = closeTagRegex.Replace(tags[i], comment.TrimEnd() + ">");
                }

                if (commentRegex.IsMatch(tags[i]))
                {
                    tags[i] = commentRegex.Replace(tags[i], "");
                }
            }

            string unnecessaryAttributesPattern = @"[idclass]+=""\w+""\s+";


            foreach (var VARIABLE in tags)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        static string ExtractSemanticTags(List<string> tags, Regex semanticHtmlRegex)
        {
            string semanticMatch = String.Empty;
            string result = String.Empty;

            for (int i = 0; i < tags.Count; i++)
            {
                if (semanticHtmlRegex.IsMatch(tags[i]))
                {
                    semanticMatch = semanticHtmlRegex.Match(tags[i]).Groups[1].ToString();
                }
            }

            return semanticMatch;
        }

        static string ExtractAttributes(List<string> tags, Regex idOrClassRegex)
        {
            string idOrClassMatch = String.Empty;

            for (int i = 0; i < tags.Count; i++)
            {
                if (idOrClassRegex.IsMatch(tags[i]))
                {
                    idOrClassMatch = idOrClassRegex.Match(tags[i]).Groups[2].ToString();
                }
            }

            return idOrClassMatch;
        }

        //static void ReplaceTags(List<string> tags, Regex divRegex)
        //{
            
        //    for (int i = 0; i < tags.Count; i++)
        //    {
        //        if (divRegex.IsMatch(tags[i]))
        //        {
        //            tags[i] = divRegex.Replace(tags[i], ExtractSemanticTags(tags));
        //        }
        //    }
        //}

        static void ReplaceSpacesInTheEnd(List<string> tags, Regex spacesInTheEndRegex)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (spacesInTheEndRegex.IsMatch(tags[i]))
                {
                    tags[i] = spacesInTheEndRegex.Replace(tags[i], "");
                }
            }
        }

        static void ReplaceMultipleSpaces(List<string> tags, Regex multipleSpacesRegex)
        {
            
            for (int i = 0; i < tags.Count; i++)
            {
                if (multipleSpacesRegex.IsMatch(tags[i]))
                {
                    tags[i] = multipleSpacesRegex.Replace(tags[i], " ");
                }
            }
        }

        static void DeleteAttributes(List<string> tags)
        {
            

            //for (int i = 0; i < tags.Count; i++)
            //{
            //    if (ExtractAttributes(tags).Contains(tags[i]))
            //    {
            //        tags[i] = tags[i].Replace(ExtractAttributes(tags), "");
            //    }

                //if (CommentRegex.IsMatch(tags[i]))
                //{
                //    tags[i] = CommentRegex.Replace(tags[i], "");
                //}
            }
        }
    }
