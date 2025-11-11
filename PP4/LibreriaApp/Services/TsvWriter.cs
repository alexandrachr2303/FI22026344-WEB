using System.IO;
using System.Linq;
using LibreriaApp.Data;

namespace LibreriaApp.Services
{
    public static class TsvWriter
    {
        public static void WriteFiles(LibreriaContext context)
        {
            Console.WriteLine("Creando archivos TSV...");
            var dataFolder = "data";

            var query = context.Authors
                .SelectMany(a => a.Titles, (a, t) => new { a.AuthorName, t.TitleId, t.TitleName })
                .SelectMany(at => context.TitlesTags.Where(tt => tt.TitleId == at.TitleId)
                    .Select(tt => new { at.AuthorName, at.TitleName, TagName = tt.Tag.TagName }));

            foreach(var group in query.GroupBy(q => q.AuthorName[0]))
            {
                var filePath = Path.Combine(dataFolder, $"{group.Key}.tsv");
                using var writer = new StreamWriter(filePath);
                writer.WriteLine("AuthorName\tTitleName\tTagName");

                foreach(var row in group.OrderByDescending(r => r.AuthorName)
                                        .ThenByDescending(r => r.TitleName)
                                        .ThenByDescending(r => r.TagName))
                {
                    writer.WriteLine($"{row.AuthorName}\t{row.TitleName}\t{row.TagName}");
                }
            }

            Console.WriteLine("Procesando... Listo.");
        }
    }
}
