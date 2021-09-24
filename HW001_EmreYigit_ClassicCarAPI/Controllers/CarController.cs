using HW001_EmreYigit_ClassicCarAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HW001_EmreYigit_ClassicCarAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public static List<CarDto> _carList = new()
        {
            new CarDto { Id = 1, Brand = "Volkswagen", Model = "Bug", ModelYear = 1966, SasiNo = "12abc12PPP99" },
            new CarDto { Id = 2, Brand = "Volkswagen", Model = "Bug", ModelYear = 1967, SasiNo = "12abc12PPA99" },
            new CarDto { Id = 3, Brand = "Volkswagen", Model = "Bug", ModelYear = 1970, SasiNo = "12abc12PPB99" },
            new CarDto { Id = 4, Brand = "Volkswagen", Model = "Bug", ModelYear = 1974, SasiNo = "12abc12BBB99" },
            new CarDto { Id = 5, Brand = "Volkswagen", Model = "Golf", ModelYear = 1974, SasiNo = "12abc12GGG99" },
            new CarDto { Id = 6, Brand = "Volkswagen", Model = "Golf", ModelYear = 1975, SasiNo = "12abc12GGH99" },
            new CarDto { Id = 7, Brand = "Volkswagen", Model = "Golf", ModelYear = 1976, SasiNo = "12abc12GGI99" },
            new CarDto { Id = 8, Brand = "Chevrolet", Model = "Malibu", ModelYear = 1975, SasiNo = "13abc12MMM99" },
            new CarDto { Id = 9, Brand = "Chevrolet", Model = "İmpala", ModelYear = 1965, SasiNo = "13abc12III99" },
            new CarDto { Id = 10, Brand = "Ford", Model = "Mustang", ModelYear = 1973, SasiNo = "11abc12MMM99" },
            new CarDto { Id = 11, Brand = "Ford", Model = "Mustang", ModelYear = 1969, SasiNo = "11abc12AAA99" },
            new CarDto { Id = 12, Brand = "Ford", Model = "Taunus", ModelYear = 1978, SasiNo = "11abc12TTT99" },
        };

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            return Ok(_carList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Get(int id)
        {
            var car = _carList.FirstOrDefault(car => car.Id == id);
            if (car != null)
            {
                return Ok(car);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] CarDto newCar)
        {
            newCar.Id = _carList.Max(car => car.Id) + 1;

            _carList.Add(newCar);

            var checkCreatedCar = _carList.FirstOrDefault(car => car.Id == newCar.Id);
            if (checkCreatedCar != null)
            {
                return Ok(newCar);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Update(int id, [FromBody] CarDto newCar)
        {
            var filterCar = _carList.FirstOrDefault(car => car.Id == id);
            if (filterCar != null)
            {
                filterCar.Brand = newCar.Brand;
                filterCar.Model = newCar.Model;
                filterCar.ModelYear = newCar.ModelYear;
                filterCar.SasiNo = newCar.SasiNo;

                return Ok(filterCar);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]

        public IActionResult Path(int id, [FromBody] CarSasiNoUpdateRequest request)
        {

            var filterCar = _carList.FirstOrDefault(car => car.Id == id);
            if (filterCar != null)
            {
                filterCar.SasiNo = request.SasiNo;
                return Ok(filterCar);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            var carToRemove = _carList.FirstOrDefault(car => car.Id == id);
            if (carToRemove != null)
            {
                _carList.Remove(carToRemove);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("filter")]
        [ProducesResponseType(200)]
        public IActionResult Filter([FromQuery] string brand)
        {
            var filterCar = _carList.FindAll(car => car.Brand == brand);
            if (filterCar.Any())
            {
                return Ok(filterCar);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
