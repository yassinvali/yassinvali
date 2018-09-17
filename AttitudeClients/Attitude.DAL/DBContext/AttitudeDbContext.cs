using AttitudeClient.DBContext.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AttitudeClient.DBContext
{
    public class AttitudeDbContext : IdentityDbContext<ApplicationUser>
    {
        public AttitudeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static AttitudeDbContext Create()
        {
            return new AttitudeDbContext();
        }
    }
}