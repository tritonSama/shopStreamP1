using Microsoft.AspNetCore.Mvc;
using shopBL;
using shopModel;

namespace shopApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private iCustomerBL _custBL;
    public CustomerController(iCustomerBL p_custBL)
    {
        _custBL = p_custBL;
    }
    
    
    [HttpGet("GetAllItem")]
    public IActionResult GetAllItem()
    {
        List<Customer> listOfCurrentCustomer = _custBL.GetAllCustomer();
        return Ok(listOfCurrentCustomer);
    } 
    
    
    [HttpPost("AddCustomer")]
    public IActionResult AddCustomer([FromBody]Customer p_cust)
    {
        _custBL.AddCustomer(p_cust);
        return Created("Customer Added", p_cust);
    }

    [HttpGet("SearchCustomerBy")]
    public IActionResult SearchCustomer([FromQuery] string custName)
    {
        return Ok(_custBL.searchCustomerByName(custName));
    }  
}
