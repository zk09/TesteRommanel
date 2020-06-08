using Microsoft.EntityFrameworkCore;

namespace User.IO.Rommanel.Infra.Data.Extensions
{
    public static class ModelBuildExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modeBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modeBuilder.Entity<TEntity>());
        }


    }
}
