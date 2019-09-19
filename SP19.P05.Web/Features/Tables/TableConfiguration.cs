using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace SP19.P05.Web.Features.Tables
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasData(new List<Table>
            {
                new Table {Id = 1, NumberOfSeats = 2, TableStatus = 'w'},
                new Table {Id = 2, NumberOfSeats = 8, TableStatus = 'w'},
                new Table {Id = 3, NumberOfSeats = 12, TableStatus = 'o'},
                new Table {Id = 4, NumberOfSeats = 4, TableStatus = 'n'},
                new Table {Id = 5, NumberOfSeats = 4, TableStatus = 'd'},
                new Table {Id = 6, NumberOfSeats = 2, TableStatus = 'n'},
                new Table {Id = 7, NumberOfSeats = 5, TableStatus = 'd'},
                new Table {Id = 8, NumberOfSeats = 3, TableStatus = 'o'},
                new Table {Id = 9, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 10, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 11, NumberOfSeats = 2, TableStatus = 'n'},
                new Table {Id = 12, NumberOfSeats = 5, TableStatus = 'd'},
                new Table {Id = 13, NumberOfSeats = 3, TableStatus = 'o'},
                new Table {Id = 14, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 15, NumberOfSeats = 2, TableStatus = 'r'},
                new Table {Id = 16, NumberOfSeats = 2, TableStatus = 'n'},
                new Table {Id = 17, NumberOfSeats = 5, TableStatus = 'd'},
                new Table {Id = 18, NumberOfSeats = 3, TableStatus = 'o'},
                new Table {Id = 19, NumberOfSeats = 4, TableStatus = 'r'},
                new Table {Id = 20, NumberOfSeats = 2, TableStatus = 'r'}
            });
        }
    }
}