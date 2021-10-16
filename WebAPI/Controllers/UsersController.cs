using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Domain;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Auth
        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult<IResponse>> Authenticate(Credentials credentials)
        {
            try
            {
                if (!String.IsNullOrEmpty(credentials.Username) && !String.IsNullOrEmpty(credentials.Password))
                {
                    var user = _context.Users
                        .Where(s => s.Username == credentials.Username && s.Password == credentials.Password)
                        .FirstOrDefault<User>();
                    if(user != null)
                    {
                        return Ok(new SuccessResponse(user));
                    }
                    else
                    {
                        Dictionary<string, string> responseData = new Dictionary<string, string>()
                        {
                            { "Not found", $"User not found"}
                        };
                        return NotFound(new FailResponse(responseData));
                    }
                }
                else
                {
                    Dictionary<string, string> responseData = new Dictionary<string, string>()
                    {
                        {"empty", $"Username or password empty"}
                    };
                    return BadRequest(new FailResponse(responseData));
                }
            }
            catch (Exception err)
            {
                return StatusCode(500, new ErrorResponse(err.Message));
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<IResponse>> Create(SignUpForm newUser)
        {
            try
            {
                // Check that both passwords are equal
                if (newUser.Password != newUser.ReEnteredPassword)
                {
                    Dictionary<string, string> responseData = new Dictionary<string, string>()
                    {
                        {"password", "Both passwords must be equal!"}
                    };
                    return BadRequest(new FailResponse(responseData));
                }

                // Basic validation to assure that any property is null
                foreach (PropertyInfo prop in newUser.GetType().GetProperties())
                {
                    if (prop.GetValue(newUser) is null)
                    {
                        Dictionary<string, string> responseData = new Dictionary<string, string>()
                        {
                            {prop.Name, $"{prop.Name} is required! {prop.GetValue(newUser)} was passed."}
                        };
                        return BadRequest(new FailResponse(responseData));
                    }
                }
                User user = new User()
                {
                    FullName = newUser.FullName,
                    Username = newUser.Username,
                    IdentificationDocument = newUser.IdentificationDocument,
                    Email = newUser.Email,
                    CreditCardNumber = newUser.CreditCardNumber,
                    CVV = newUser.CVV,
                    CreditCardExpirationDate = newUser.CreditCardExpirationDate,
                    Password = newUser.Password,
                    Balance = 250.5f
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new SuccessResponse(user));
            }
            catch (Exception err)
            {
                return StatusCode(500, new ErrorResponse(err.Message));
            }
        }
        [HttpPost]
        [Route("Deposit")]
        public async Task<ActionResult<IResponse>> Deposit(TransactionForm transactionrequest)
        {
            try
            {
                

                // Basic validation to assure that any property is null                
                if (transactionrequest.UserID==0||transactionrequest.Balance==0)
                {                    
                    return BadRequest(new FailResponse("Cannot create a transaction with 0 balance value or no userID"));
                }
                
                BalanceTransaction balanceTransaction = new BalanceTransaction()
                {
                   UserID = transactionrequest.UserID,
                   Balance = transactionrequest.Balance
                };
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var user = _context.Users.FirstOrDefault(u => u.Id == transactionrequest.UserID);
                        if (user is null)
                        {
                            return BadRequest(new FailResponse("User no longer exist."));
                        }
                        user.Balance += transactionrequest.Balance;
                        _context.BalanceTransactions.Add(balanceTransaction);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("An error has ocurred in the database transaction.", ex);
                    }
                }
                
                return Ok(new SuccessResponse(_context.Users.Find(balanceTransaction.UserID)));
            }
            catch (Exception err)
            {
                return StatusCode(500, new ErrorResponse(err.Message));
            }
        }

        [HttpPost]
        [Route("Withdraw")]
        public async Task<ActionResult<IResponse>> Withdraw(TransactionForm transactionrequest)
        {
            try
            {
                // Basic validation to assure that any property is null                
                if (transactionrequest.UserID == 0 || transactionrequest.Balance == 0)
                {
                    return BadRequest(new FailResponse("Cannot create a transaction with 0 balance value or no userID"));
                }

                BalanceTransaction balanceTransaction = new BalanceTransaction()
                {
                    UserID = transactionrequest.UserID,
                    Balance = transactionrequest.Balance* -1
                };
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var user = _context.Users.FirstOrDefault(u => u.Id == transactionrequest.UserID);
                        if (user is null)
                        {
                            return BadRequest(new FailResponse("User no longer exist."));
                        }
                        user.Balance -= transactionrequest.Balance;
                        _context.BalanceTransactions.Add(balanceTransaction);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("An error has ocurred in the database transaction.", ex);
                    }
                }

                return Ok(new SuccessResponse(_context.Users.Find(balanceTransaction.UserID)));
            }
            catch (Exception err)
            {
                return StatusCode(500, new ErrorResponse(err.Message));
            }
        }
    }
}
