#from tye
grpcurl `
    -d '{\"phoneNumber\": \"+8yDS3o9cSZEIZ7sPLOWHhZclQCBarXFKDomOfLJoHxl671+sVwQhkM/9KE/kcBJbupFczN3YMbU0Wrq6ru+MQ==3375653\"}' `
    -plaintext localhost:1234 Features.Velocity.GetVelocity

grpcurl `
    -d '{\"phoneNumber\": \"381652582588\"}' `
    -plaintext localhost:1234 Features.Velocity.GetVelocity

#from VS
grpcurl `
    -d '{\"phoneNumber\": \"+8yDS3o9cSZEIZ7sPLOWHhZclQCBarXFKDomOfLJoHxl671+sVwQhkM/9KE/kcBJbupFczN3YMbU0Wrq6ru+MQ==3375653\"}' `
    -plaintext localhost:5000 Features.Velocity.GetVelocity
