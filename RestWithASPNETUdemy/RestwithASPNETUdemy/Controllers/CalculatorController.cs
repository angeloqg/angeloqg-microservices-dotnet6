using Microsoft.AspNetCore.Mvc;

namespace RestwithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{scondNumber}")]
    public IActionResult Sum(string firstNumber, string scondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(scondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(scondNumber);

            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("subtract/{firstNumber}/{scondNumber}")]
    public IActionResult Subtract(string firstNumber, string scondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(scondNumber))
        {
            var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(scondNumber);

            return Ok(subtract.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{scondNumber}")]
    public IActionResult Multiplication(string firstNumber, string scondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(scondNumber))
        {
            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(scondNumber);

            return Ok(multiplication.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{scondNumber}")]
    public IActionResult Division(string firstNumber, string scondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(scondNumber))
        {
            try
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(scondNumber);

                return Ok(division.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            try
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(squareRoot.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("mean/{firstNumber}/{scondNumber}")]
    public IActionResult Mean(string firstNumber, string scondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(scondNumber))
        {
            var average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(scondNumber)) / 2;

            return Ok(average.ToString());
        }

        return BadRequest("Invalid Input");
    }


    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, 
                                        System.Globalization.NumberStyles.Any, 
                                        System.Globalization.NumberFormatInfo.InvariantInfo, 
                                        out number);
        return isNumber;
    }

    private decimal ConvertToDecimal(string firstNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(firstNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }
}
