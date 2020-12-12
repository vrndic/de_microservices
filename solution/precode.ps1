dotnet new grpc -n grpcVelocity
dotnet new grpc -n grpcFeatureCollector

dotnet new sln -n de_microservices

dotnet sln add grpcVelocity
dotnet sln add grpcFeatureCollector