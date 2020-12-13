ghz  --insecure `
--proto ./Protos/velocity.proto `
--call Features.Velocity.GetVelocity `
-d  '{\"phoneNumber\": \"+8yDS3o9cSZEIZ7sPLOWHhZclQCBarXFKDomOfLJoHxl671+sVwQhkM/9KE/kcBJbupFczN3YMbU0Wrq6ru+MQ==3375653\"}' `
-n 300 `
-c 30 `
--connections=30 `
127.0.0.1:1234





ghz  --insecure `
--proto ./grpcServer/Protos/server.proto `
--call server.Server.GetVelocity `
-d '{"""name""":"""ruuuxn"""}' `
-n 100 `
-c 10 `
--connections=3 `
127.0.0.1:7000


ghz  --insecure `
--proto ./grpcclient/Protos/client.proto `
--call client.Call.SayHello `
-d '{"""name""":"""nemkara"""}' `
-n 100 `
-c 8 `
--connections=8 `
127.0.0.1:1235