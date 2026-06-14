// Global using directives

global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using BMDb.Core.Configs;
global using BMDb.Core.RepositoryContracts;
global using BMDb.Core.ServiceContracts;
global using BMDb.Domain.Entities;
global using BMDb.Infrastructure.Data;
global using BMDb.Infrastructure.Repositories;
global using BMDb.Infrastructure.Services;
global using MailKit.Net.Smtp;
global using MailKit.Security;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using MimeKit;