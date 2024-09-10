using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class UserForRegisterExtendedDto 
{
    public string NickName { get; set; }

    public string PhoneNumber { get; set; }

    public UserForRegisterDto UserForRegisterDto { get; set; }

    public string PasswordConfirm { get; set; }
}
