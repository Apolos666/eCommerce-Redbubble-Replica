SELECT u.Id, u.UserName, u.Email, u.PasswordHash, u.LockoutEnabled, u.LockoutEnd, u.AccessFailedCount, 
c.ClaimType, c.ClaimValue, r.Name
FROM AspNetUsers u
LEFT JOIN AspNetUserClaims c ON u.Id = c.UserId
LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
LEFT JOIN AspNetRoles r On r.Id = ur.RoleId;