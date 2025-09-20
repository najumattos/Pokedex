using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonTipoController : Controller
    {
        private readonly AppDbContext _context;

        public PokemonTipoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PokemonTipo
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PokemonTipos.Include(p => p.Pokemon).Include(p => p.Tipo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PokemonTipo/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonTipo = await _context.PokemonTipos
                .Include(p => p.Pokemon)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.PokemonNumero == id);
            if (pokemonTipo == null)
            {
                return NotFound();
            }

            return View(pokemonTipo);
        }

        // GET: PokemonTipo/Create
        public IActionResult Create()
        {
            ViewData["PokemonNumero"] = new SelectList(_context.Pokemons, "Numero", "Nome");
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome");
            return View();
        }

        // POST: PokemonTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PokemonNumero,TipoId")] PokemonTipo pokemonTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemonTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PokemonNumero"] = new SelectList(_context.Pokemons, "Numero", "Nome", pokemonTipo.PokemonNumero);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome", pokemonTipo.TipoId);
            return View(pokemonTipo);
        }

        // GET: PokemonTipo/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonTipo = await _context.PokemonTipos.FindAsync(id);
            if (pokemonTipo == null)
            {
                return NotFound();
            }
            ViewData["PokemonNumero"] = new SelectList(_context.Pokemons, "Numero", "Nome", pokemonTipo.PokemonNumero);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome", pokemonTipo.TipoId);
            return View(pokemonTipo);
        }

        // POST: PokemonTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("PokemonNumero,TipoId")] PokemonTipo pokemonTipo)
        {
            if (id != pokemonTipo.PokemonNumero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemonTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonTipoExists(pokemonTipo.PokemonNumero))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PokemonNumero"] = new SelectList(_context.Pokemons, "Numero", "Nome", pokemonTipo.PokemonNumero);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome", pokemonTipo.TipoId);
            return View(pokemonTipo);
        }

        // GET: PokemonTipo/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonTipo = await _context.PokemonTipos
                .Include(p => p.Pokemon)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.PokemonNumero == id);
            if (pokemonTipo == null)
            {
                return NotFound();
            }

            return View(pokemonTipo);
        }

        // POST: PokemonTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var pokemonTipo = await _context.PokemonTipos.FindAsync(id);
            if (pokemonTipo != null)
            {
                _context.PokemonTipos.Remove(pokemonTipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonTipoExists(uint id)
        {
            return _context.PokemonTipos.Any(e => e.PokemonNumero == id);
        }
    }
}
