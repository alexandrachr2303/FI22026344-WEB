using CsvHelper;
using System.Globalization;
using System.IO;
using LibreriaApp.Data;
using LibreriaApp.Models;
using System.Linq;

namespace LibreriaApp.Services
{
    public static class DataLoader
    {
        public static void LoadCsvIfEmpty(LibreriaContext context)
        {
            Console.WriteLine("La base de datos está vacía, llenando desde CSV...");

            using var reader = new StreamReader("data/books.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<dynamic>();

            foreach(var record in records)
            {
                string authorName = record.Author;
                string titleName = record.Title;
                string[] tags = record.Tags.Split('|');

                var author = context.Authors.FirstOrDefault(a => a.AuthorName == authorName);
                if(author == null)
                {
                    author = new Author { AuthorName = authorName };
                    context.Authors.Add(author);
                    context.SaveChanges();
                }

                var title = new Title { TitleName = titleName, AuthorId = author.AuthorId };
                context.Titles.Add(title);
                context.SaveChanges();

                foreach(var tagName in tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.TagName == tagName);
                    if(tag == null)
                    {
                        tag = new Tag { TagName = tagName };
                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }

                    context.TitlesTags.Add(new TitleTag { TitleId = title.TitleId, TagId = tag.TagId });
                }
            }

            context.SaveChanges();
            Console.WriteLine("Procesando... Listo.");
        }
    }
}
