using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiGestioneViaggi.Models;
using WebApiGestioneViaggi.Models.Comunica;
using WebApiGestioneViaggi.Persistence;

namespace WebApiGestioneViaggi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaGeograficaController : ControllerBase
    {
        private readonly ILogger<AreaGeograficaController> _logger;
        private DatabaseCxt _context;
        public AreaGeograficaController(ILogger<AreaGeograficaController> logger, DatabaseCxt ctx)
        {
            _logger = logger;
            _context = ctx;
          
        }

        [HttpGet("Countries")]
        public async Task<IActionResult> Get()
        {


            var country = await _context.Country.ToListAsync();
           
            return Ok(country);
        }




        [HttpGet("CountryName/{Name}")]
        public async Task<IActionResult> GetByCountryName(string Name)
        {

            Country c = null;
            using (_context)
            {
                c = await _context.Country.Where(c => c.Nome == Name).FirstAsync();
                var data = _context.Country
               .Include(ct => ct.Cities)
               .First(c => c.Id == c.Id);

                return Ok(data);
            }
           

        }

        [HttpGet("CityName/{Name}")]
        public async Task<IActionResult> GetByCityName(string Name)
        {
            City c = null;
            using (_context)
            {
                try
                {
                    c = await _context.City.Where(c => c.Nome == Name).FirstAsync();
                    return Ok(c);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }

        [HttpPut("ModificaCitta")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveCityResource modifica)
        {
            var citta = await _context.City.FindAsync(id);
            var npNonModificato = citta.NumeroPositivi;
            var city = await _context.City.FindAsync(id);
            City rstCity = modifica.ToCity();
            city.NumeroPositivi = rstCity.NumeroPositivi;
            var result = _context.City.Update(city).Entity;
            try
            {
                var res = await _context.SaveChangesAsync();
                Country country = await _context.Country.Where(c=>c.Id == city.CountryId).FirstAsync();
                Continent continent = await _context.Continent.Where(c => c.Id == country.ContinentId).FirstAsync();


                if (npNonModificato < result.NumeroPositivi)
                {
                    var differenzaPositivi = result.NumeroPositivi - npNonModificato;
                    country.NumeroPositivi = country.NumeroPositivi + differenzaPositivi;
                    continent.NumeroPositivi = continent.NumeroPositivi + differenzaPositivi;
                    _context.SaveChanges();
                    if (country.NumeroPositivi > 500000)
                    {
                        country.Area = "Red";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi > 100000 && country.NumeroPositivi <= 500000)
                    {
                        country.Area = "Orange";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi > 10000 && country.NumeroPositivi <= 100000)
                    {
                        country.Area = "Yellow";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi <= 10000)
                    {
                        country.Area = "White";
                        _context.SaveChanges();
                    }

                }
                else if (npNonModificato > result.NumeroPositivi)
                {
                    var differenzaPositivi = npNonModificato - result.NumeroPositivi ;
                    country.NumeroPositivi = country.NumeroPositivi - differenzaPositivi;
                    continent.NumeroPositivi = continent.NumeroPositivi - differenzaPositivi;
                    _context.SaveChanges();
                    if (country.NumeroPositivi > 500000)
                    {
                        country.Area = "Red";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi > 100000 && country.NumeroPositivi <= 500000)
                    {
                        country.Area = "Orange";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi > 10000 && country.NumeroPositivi <= 100000)
                    {
                        country.Area = "Yellow";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi <= 10000)
                    {
                        country.Area = "White";
                        _context.SaveChanges();
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpDelete("DeleteCity/{id}")]
        public async Task Delete(int id)
        {
            City citta = await _context.City.FindAsync(id);
            
            _context.City.Remove(citta);
            await _context.SaveChangesAsync();

            Country country = await _context.Country.Where(c => c.Id == citta.CountryId).FirstAsync();
            var NumeroPositiviCountry = country.NumeroPositivi - citta.NumeroPositivi;
            country.NumeroPositivi = NumeroPositiviCountry;
            await _context.SaveChangesAsync();

            Continent continent = await _context.Continent.Where(c => c.Id == country.ContinentId).FirstAsync();
            var numeroPositiviContinent = continent.NumeroPositivi - country.NumeroPositivi;
            await _context.SaveChangesAsync();

            if (country.NumeroPositivi > 500000)
            {
                country.Area = "Red";
                _context.SaveChanges();
            }

            if (country.NumeroPositivi > 100000 && country.NumeroPositivi <= 500000)
            {
                country.Area = "Orange";
                _context.SaveChanges();
            }

            if (country.NumeroPositivi > 10000 && country.NumeroPositivi <= 100000)
            {
                country.Area = "Yellow";
                _context.SaveChanges();
            }

            if (country.NumeroPositivi <= 10000)
            {
                country.Area = "White";
                _context.SaveChanges();
            }

        }



        [HttpPost("AddCity")]
        public async Task<IActionResult> Post([FromBody] CreateNewCity value)
        {
            City city = null;
            Country country = null;
            Continent continent = null;
            try
            {
                try
                {
                    city = _context.City.Add(value.CreateCity()).Entity;
                    _context.SaveChanges();
                    country =await _context.Country.Where(c => c.Id == city.CountryId).FirstAsync();
                    country.Cities.Add(city);
                    country.NumeroPositivi= country.NumeroPositivi + city.NumeroPositivi;
                    _context.SaveChanges();

                    continent = await _context.Continent.Where(c => c.Id == country.ContinentId).FirstAsync();
                    continent.NumeroPositivi = continent.NumeroPositivi + city.NumeroPositivi;
                    _context.SaveChanges();

                    if (country.NumeroPositivi > 500000)
                    {
                        country.Area = "Red";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi > 100000 && country.NumeroPositivi <= 500000)
                    {
                        country.Area = "Orange";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi > 10000 && country.NumeroPositivi <= 100000)
                    {
                        country.Area = "Yellow";
                        _context.SaveChanges();
                    }

                    if (country.NumeroPositivi <= 10000)
                    {
                        country.Area = "White";
                        _context.SaveChanges();
                    }

                    return Ok(city);
                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}
