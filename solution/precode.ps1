/* Create projects */
dotnet new grpc -n grpcVelocity
dotnet new grpc -n grpcFeatureCollector

/* Create solution */
dotnet new sln -n de_microservices

/* Add project to solution */
dotnet sln add grpcVelocity
dotnet sln add grpcFeatureCollector

/* Add needed packages to project */
cd ./grpcVelocity


#server
dotnet add package Dapr.AspNetCore --version 0.11.0-preview02
dotnet add package AWSSDK.DynamoDBv2 --version 3.5.4.7
dotnet add package Grpc.AspNetCore.Server.Reflection --version 2.34.0
dotnet add package AWSSDK.Extensions.NETCore.Setup