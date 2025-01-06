using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS
{
    public class Util
    {
        public static void GenerateSampleCategory()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category(1, "Drink"));
            categories.Add(new Category(2, "Noodle"));
            categories.Add(new Category(3, "Baker"));
            new FileManager().Wirte("Category", categories);

        }
    }
}
