# hp-banking-system
Banking app for Microservices assessment with docker. This application is in dotnet core 2.2 and uses docker containers on Linux.

##### Accounts API
To check Accounts API [click here!](http://localhost:7001/swagger)

##### Loans API
To check Loans API [click here!](http://localhost:7002/swagger)

##### Identity API
To check Identity API [click here!](http://localhost:7003/swagger)

##### API Gateway
To check API gateway configure URLs as follows,
> http://localhost:7100/api/v1/ + (accounts or loans or identity) + /{Everything after v1/ in Swagger}

### Architecture Diagram
![Image of Yaktocat](https://raw.githubusercontent.com/harshjp722/hp-banking-system/master/Docs/Microservices.png)

### Benifits of Microservice Architecture over Monolithic Architecture
![Image of Yaktocat](https://raw.githubusercontent.com/harshjp722/hp-banking-system/master/Docs/Microservices-vs-Monolith.jpg)
* __Independent components.__ Firstly, all the services can be deployed and updated independently, which gives more flexibility. Secondly, a bug in one microservice has an impact only on a particular service and does not influence the entire application. Also, it is much easier to add new features to a microservice application than a monolithic one.
* __Easier understanding.__ Split up into smaller and simpler components, a microservice application is easier to understand and manage. You just concentrate on a specific service that is related to a business goal you have.
* __Better scalability.__ Another advantage of the microservices approach is that each element can be scaled independently. So the entire process is more cost- and time-effective than with monoliths when the whole application has to be scaled even if there is no need in it. In addition, every monolith has limits in terms of scalability, so the more users you acquire, the more problems you have with your monolith.

### Scale Application
Docker applications can be scaled using clustering. Following are some well known tools for managing docker container clusters.
* __Docker Swarm__
* __Google Kubernetes__
