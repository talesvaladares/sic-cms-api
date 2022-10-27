using sic_cms.Entities;
using Microsoft.EntityFrameworkCore;
using sic_cms.Helpers;

namespace sic_cms.Services {


    public interface IMenuService {
        public Task<List<Menu>> GetAll();
        public Task<Menu> Create(Menu menu);
        public Task Delete(int id);

        public Task Update(Menu menu);
    }
    public class MenuService : IMenuService {

        private readonly DataContext _context;

        public MenuService(DataContext context) {
            _context = context;
        }

        public async Task<List<Menu>> GetAll() => await _context.Menu.ToListAsync();

        public async Task<Menu> Create(Menu menu) {


            try {

                _context.Menu.Add(menu);
                await _context.SaveChangesAsync();
                return menu;

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return menu;
        }

        public async Task Delete(int id) {

            try {
                Menu menuDb = await _context.Menu.SingleOrDefaultAsync(m => m.Id == id);

                if (menuDb is null) {
                    throw new KeyNotFoundException($"Menu {id} not found");
                }

                _context.Menu.Remove(menuDb);
                await _context.SaveChangesAsync();

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            
        }

        public async Task Update(Menu menu) {
            

            Menu menuDb = await _context.Menu
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == menu.Id);

            if (menuDb is null) {
                throw new KeyNotFoundException($"User { menu.Id} not found");
            }

            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
