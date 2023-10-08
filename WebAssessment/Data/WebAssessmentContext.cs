using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAssessment;

namespace WebAssessment.Data
{
    public class WebAssessmentContext : DbContext
    {
        public WebAssessmentContext (DbContextOptions<WebAssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<WebAssessment.UserDetails> UserDetails { get; set; } = default!;
    }
}
