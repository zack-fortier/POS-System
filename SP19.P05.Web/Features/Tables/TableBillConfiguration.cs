using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP19.P05.Web.Features.Tables
{
    public class TableBillConfiguration : IEntityTypeConfiguration<TableBill>
    {
        public void Configure(EntityTypeBuilder<TableBill> builder)
        {
        }
    }
}