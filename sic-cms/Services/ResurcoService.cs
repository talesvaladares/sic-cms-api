using sic_cms.Entities;
using Microsoft.EntityFrameworkCore;
using sic_cms.Helpers;

namespace sic_cms.Services {


    public interface IRecursoService {
        public Task<List<Recurso>> GetAll();

        public Task<Recurso> GetByCod(string codigo);
        public Task<Recurso> Create(Recurso Recurso);
        public Task Delete(string codigo);

        public Task Update(Recurso Recurso);
    }
    public class RecursoService : IRecursoService {

        private readonly DataContext _context;

        public RecursoService(DataContext context) {
            _context = context;
        }

        public async Task<List<Recurso>> GetAll() => await _context.Recurso.ToListAsync();

        public async Task<Recurso> Create(Recurso Recurso) {


            try {

                _context.Recurso.Add(Recurso);
                await _context.SaveChangesAsync();
                return Recurso;

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return Recurso;
        }

        public async Task Delete(string codigo) {

            try {
                Recurso RecursoDb = await _context.Recurso.SingleOrDefaultAsync(r => r.Codigo == codigo);

                if (RecursoDb is null) {
                    throw new KeyNotFoundException($"Recurso {codigo} not found");
                }

                _context.Recurso.Remove(RecursoDb);
                await _context.SaveChangesAsync();

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            
        }

        public async Task Update(Recurso recurso) {
            

            Recurso RecursoDb = await _context.Recurso
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.Codigo == recurso.Codigo);

            if (RecursoDb is null) {
                throw new KeyNotFoundException($"User { recurso.Codigo} not found");
            }

            _context.Entry(recurso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Recurso> GetByCod(string codigo) {
           
            Recurso recursoDB = await _context.Recurso
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.Codigo == codigo);

            return recursoDB;
        }
    }
}
