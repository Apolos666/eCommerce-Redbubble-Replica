﻿using System.ComponentModel.DataAnnotations;

namespace api.DTOs.IdentityDTOs;

public class UserRegister
{
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string UserEmail { get; set; }
    
    [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Tên người dùng phải có ít nhất 6 ký tự")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ cái viết hoa, một chữ cái viết thường và một số")]
    public string Password { get; set; }
}

