// Global using directives

global using System.Collections.Concurrent;
global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using System.Text.RegularExpressions;
global using AutoMapper;
global using BMDb.Core.Configs;
global using BMDb.Core.DTOs;
global using BMDb.Core.Mappings;
global using BMDb.Core.RepositoryContracts;
global using BMDb.Core.ServiceContracts;
global using BMDb.Core.Services;
global using BMDb.Core.Validators;
global using BMDb.Domain.Entities;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MailKit.Net.Smtp;
global using MailKit.Security;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using MimeKit;