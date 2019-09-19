using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Tables;
using SP19.P05.Web.Hubs;

namespace SP19.P05.Web.Controllers
{
    public class TablesController : ApiBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IHubContext<NotificationHub> hubContext;


        public TablesController(DataContext dataContext, IMapper mapper, IHubContext<NotificationHub> hubContext)
        {

            this.dataContext = dataContext;
            this.mapper = mapper;
            this.hubContext = hubContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> Get()
        {
            var entityQueryable = dataContext.Set<Table>();
            var dtoQueryable = mapper.ProjectTo<TableDto>(entityQueryable);
            var itemDtos = await dtoQueryable.ToArrayAsync();
            return itemDtos;
        }

        [HttpPut]
        public async Task<ActionResult<TableDto>> Put(TableDto dto)
        {
            var entity = await dataContext.Set<Table>().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                return NotFound();
            }
            mapper.Map(dto, entity);
            await dataContext.SaveChangesAsync();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<TableDto>> Post(TableDto dto)
        {
            var entity = new Table();
            mapper.Map(dto, entity);
            dataContext.Add(entity);
            await dataContext.SaveChangesAsync();
            dto.Id = entity.Id;
            return dto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await dataContext.Set<Table>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            dataContext.Remove(entity);
            await dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("CheckIn")]
        public async Task<ActionResult> CheckIn(CheckInDto checkInDto)
        {
            await hubContext.Clients.All.SendAsync("checkIn", checkInDto);
        
            return Ok();


        }
        [HttpPut("NeedAttention")]
        public async Task<ActionResult> NeedAttention(AttentionDto attentionDto)
        {
              await hubContext.Clients.All.SendAsync("needAttention", attentionDto.TableId);
            return Ok();


        }
        [HttpPut("checkedOut")]
        public async Task<ActionResult> checkedOut(AttentionDto attentionDto)
        {
           
            await hubContext.Clients.All.SendAsync("checkedOut", attentionDto.TableId);

            return Ok();


        }
        [HttpPut("NeedRefil")]
        public async Task<ActionResult> NeedRefil(RefilDto refilDto)
        {
            await hubContext.Clients.All.SendAsync("needRefil", refilDto.TableId, refilDto.refil);

            return Ok();


        }
        [HttpPut("orderFood")]
        public async Task<ActionResult> orderFood(AttentionDto attentionDto)
        {
            await hubContext.Clients.All.SendAsync("orderFood", attentionDto.TableId);
            return Ok();


        }


        [HttpGet("GetTables")]
        public ActionResult GetTables()
        {
            var tables = new List<Table>()
            {
                new Table {Id = 1, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 2, NumberOfSeats = 8, TableStatus = 'r'},
                new Table {Id = 3, NumberOfSeats = 12, TableStatus = 'r'},
                new Table {Id = 4, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 5, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 6, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 7, NumberOfSeats = 5, TableStatus = 'r'},
                new Table {Id = 8, NumberOfSeats = 3, TableStatus = 'r'},
                new Table {Id = 9, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 10, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 11, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 12, NumberOfSeats = 5, TableStatus = 'r'},
                new Table {Id = 13, NumberOfSeats = 3, TableStatus = 'r'},
                new Table {Id = 14, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 15, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 16, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 17, NumberOfSeats = 5, TableStatus = 'r'},
                new Table {Id = 18, NumberOfSeats = 3, TableStatus = 'r'},
                new Table {Id = 19, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 20, NumberOfSeats = 2, TableStatus = 'r'},
            };

            return Ok(tables);
        }
        [HttpGet("GetReservation")]
        public ActionResult GetReservation()
        {
            var reservation = new List<Reservation>()
            {
            new Reservation { Id = 1, Name = "Avash", DateTime = new System.DateTime(2019, 3, 15,6,30,0).ToString("U",
                  CultureInfo.CreateSpecificCulture("en-US")) },
             new Reservation { Id = 1, Name = "Awazraith", DateTime = new System.DateTime(2019, 5, 15,6,30,0).ToString("U",
                  CultureInfo.CreateSpecificCulture("en-US")) },
              new Reservation { Id = 1, Name = "Aishte", DateTime = new System.DateTime(2019, 9, 15,9,30,0).ToString("U",
                  CultureInfo.CreateSpecificCulture("en-US")) },
            new Reservation { Id = 2, Name = "Uchiha",  DateTime = new System.DateTime(2019, 4, 15,7,30,0).ToString("U",
                  CultureInfo.CreateSpecificCulture("en-US")) }
            };
             return Ok(reservation);
        }
           
     }
}
