using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Flow.Operations.Menu.Queries
{
    public class GetMenu : DbOutOperationAsync<List<MenuModel>>
    {
        protected override async Task ExecutionAsync()
        {
            var menus = (await NewSql(sql => sql.Select("[Flow].[Menu]")
                    .Where("IsDeleted=0 AND IsActive=1")
                    .OrderBy("[Index] ASC"))
                .QueryAsync<MenuModel>()).ToList();

            foreach (var menu in menus.Where(menu => menu.ParentId != null))
                menus.Find(x => x.Id == menu.ParentId)?.Children.Add(menu);

            menus = menus.Where(x => x.ParentId == null).OrderBy(x => x.Index).ToList();
            Output = menus.Where(HasAnyChildWithLink).ToList();
        }

        private static bool HasAnyChildWithLink(MenuModel menu) =>
            !string.IsNullOrEmpty(menu.Link?.Trim()) || menu.Children.Any(HasAnyChildWithLink);
    }

    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public int Index { get; set; }
        public string? Link { get; set; }
        public string? Icon { get; set; }
        public string ColorHex { get; set; }
        public List<MenuModel> Children { get; set; } = new ();
    }
}
