using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Repositories;
using LogisticsDeliveryManagementSystem.Models;

[Route("api/[controller]")]
[ApiController]
public class PackageController : ControllerBase
{
    private readonly IPackageRepository _packageRepo;

    public PackageController(IPackageRepository packageRepo)
    {
        _packageRepo = packageRepo ?? throw new ArgumentNullException(nameof(packageRepo));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPackages()
    {
        try
        {
            var packages = await _packageRepo.GetAllPackagesAsync();
            return Ok(packages);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while fetching packages.", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPackage([FromBody] Package package)
    {
        if (package == null)
        {
            return BadRequest(new { message = "Invalid package data." });
        }

        try
        {
            var newPackage = await _packageRepo.AddPackageAsync(package);
            if (newPackage == null)
            {
                return StatusCode(500, new { message = "Failed to add package." });
            }

            return CreatedAtAction(nameof(GetAllPackages), new { id = newPackage.Id }, newPackage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while adding the package.", error = ex.Message });
        }
    }

    [HttpPatch]
    public async Task<IActionResult> MarkAsDelivered(Guid id)
    {
        try
        {
            string packageId = id.ToString();
            var package = await _packageRepo.GetPackageByIdAsync(packageId);
            if (package == null)
            {
                return NotFound(new { message = "Package not found." });
            }

            await _packageRepo.MarkPackageAsDeliveredAsync(packageId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the package status.", error = ex.Message });
        }
    }
}
