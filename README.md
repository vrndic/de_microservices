# de_microservices

Motivacija: Implementacija skorovanja u telesign, istiskuje dupli razvoj fičersa/varijabli. Iz tog razloga, dva tima rade razvoj iste logike prolazeći kroz ceo ciklus razvoja. Ne retko dolazi i do neusaglašenosti izmedju logike koja se razvija u fazi protopizacije i produkcije. 

- Folder dependency sadrzi DI kontejenre
- Kreirao sam FactorySetup kao DI kontejner, koji sluzi za podesavanje ulaznih podatak za racunanje varijable.

- Dodao sam AWSSDK.Extensions.NETCore.Setup kako bih mogao da koristim Configuration servis.

- Dodao sam folder grpccurl, sluzi kao curl za http. 

- Da bi ovo koristili moramo da enablujemo reflection na serveru, ne moze tako lako darp da se testira, ali ga inicijalno testiram za logiku. Dapr 
    https://docs.microsoft.com/en-us/aspnet/core/grpc/test-tools?view=aspnetcore-5.0
    dotnet add package Grpc.AspNetCore.Server.Reflection --version 2.34.0

- Dodao sam redis kao state store za dapr, kako bih imao verodostojan primer.
- Dodao sam skriptu za benchmark.
- Dodao sam redis za traceing

