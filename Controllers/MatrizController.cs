using Microsoft.AspNetCore.Mvc;
using System;


namespace MatrizWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatrixController : ControllerBase
    {
        [HttpPost("rotate")]
        public IActionResult RotateMatrix([FromBody] int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix.Length != matrix[0].Length)
            {
                return BadRequest("La entrada debe ser una matriz NxN no vacía.");
            }

            try
            {
                int n = matrix.Length;
                int[][] rotatedMatrix = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    rotatedMatrix[i] = new int[n];
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        rotatedMatrix[n - j - 1][i] = matrix[i][j];
                    }
                }            


                return Ok(rotatedMatrix);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
