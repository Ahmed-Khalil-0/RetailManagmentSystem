﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace DataManager.App_Start
{
    public class AuthorizationOperationFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add( "/token" , new PathItem() {
                post = new Operation()
                {
                    tags = new List<string>{"Auth"},
                    consumes = new List<string> { "application/x-www-form-urlencoded" },
                    parameters = new List<Parameter>
                    {
                        new Parameter()
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },
                        new Parameter()
                        {
                            type = "String",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter()
                        {
                            type = "string",
                            name = "Password",
                            required = false,
                            @in = "formData"
                        }
                    }
                }
            } );
        }
    }
}