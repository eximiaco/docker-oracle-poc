using System;
using System.Collections.Generic;
using System.Linq;
using docker_oracle_poc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using docker_oracle_poc.Data;
using docker_oracle_poc.Data.Entities;

namespace docker_oracle_poc.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CertificatesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CertificatesController> _logger;
        private readonly DataContext _context;

        public CertificatesController(ILogger<CertificatesController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }       

        
        [HttpGet]
        public IEnumerable<Certificate> GetCertificates()
        {
           return _context.Certificates.ToList();
        }


        [HttpPost]
        public void AddCertificate(int number)
        {
            _context.Certificates.Add(new Certificate(Guid.NewGuid(), number));
            _context.SaveChanges();
        }
    }
}