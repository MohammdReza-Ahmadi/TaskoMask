# What is TaskoMask?


  
<p align="left">
  <a href="https://github.com/hamed-shirbandi/TaskoMask/issues">
  <img alt="GitHub issues" src="https://img.shields.io/github/issues/hamed-shirbandi/TaskoMask">
</a>
 <a href="http://taskomask.ir">
  <img src="https://img.shields.io/website?url=http://taskomask.ir">
</a>
   <a href="https://github.com/hamed-shirbandi/TaskoMask/blob/master/LICENSE">
 <img src="https://img.shields.io/github/license/hamed-shirbandi/TaskoMask">
</a>
 <a href="https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors">
  <img src="https://img.shields.io/github/contributors/hamed-shirbandi/TaskoMask">
</a>
  <!--- 
   <a href="#s">
<img src="https://img.shields.io/github/workflow/status/hamed-shirbandi/TaskoMask/.NET%20Core%20Build">
</a>
 ---> 
 
  

</p>


[TaskoMask](http://taskomask.ir/) is a free and open-source task management system based on .Net. This project is [online](http://taskomask.ir/), and everyone can use it as a team member or project owner.
But the primary goal of this project is to be an effort to show how we can implement software technologies and patterns by .Net, so this can be used by developers who are looking for a real example project with real challenges. Please take a look at its [wiki](https://github.com/hamed-shirbandi/TaskoMask/wiki)!

Try it online:
[`Website`](http://taskomask.ir/) - [`User Panel`](http://panel.taskomask.ir) - [`Admin Panel`](http://admin.taskomask.ir/) - [`API`](http://api.taskomask.ir/)

![taskomask website](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/images/taskomask-all-in-one-0.jpg)
# Documentation
We are trying to document all necessary information so you can use them to get more information about what we did and how we did and why!
There is a list of our documentation:

  - ### [User Guide Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/User-Guide-Documentation):
    This can be used by developers who want to know more about the website, user panel, and admin panel or by end-users who want to use the TaskoMask application to manage their project's tasks. 
    TaskoMask contains 4 web projects as below:
    
     - [Website](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Presentation/3-UI/Website): This part is implemented with ASP.NET MVC and it contains the website for TaskoMask. As we sayed it is [online](http://taskomask.ir/) and we use it as a landing page to introduce TaskoMask and some users activity information.
     - [User Panel](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Presentation/3-UI/UserPanel): This part is implemented with **Blazor** and it contains a user panel for managing users' tasks. it is [online](http://panel.taskomask.ir) and everybody can register and use it.
     - [Admin Panel](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Presentation/3-UI/AdminPanel): This part is implemented with ASP.NET MVC, and it contains a panel to manage whole TaskoMask data by administrators. To check its featchures we made it [online](http://admin.taskomask.ir/) by using a temp DB.
     - [API](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Presentation/2-API/UserPanelAPI): This part is implemented with ASP.NET Web API and it contains API services for TaskoMask clients. You can check it [online](http://api.taskomask.ir/)
  - ### [Domain Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Domain-Documentation):
    This is for developers to be familiar with the domain model, understand the entities and relations and rules and variants, etc. By reading this doc, you can understand the business of this project.
  - ### [Architecture Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Architecture-Documentation):
    This doc is about the architecture, pipelines, technologies, patterns, approaches, decisions, and other things we implemented in this project. We talk about our choices and decisions, and challenges.
  - ### [API Documentation](https://github.com/hamed-shirbandi/TaskoMask/wiki/Rest-Api-Documentation):
    This is a live API documentation generated by Swagger, It can be used by front-end or mobile developers to make a client app. For example, we use it in [User Panel](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Presentation/3-UI/UserPanel) layer to create a web client by **Blazor**.

# Architecture And Tools
  * ### Back-end:
      - .Net 6 
      - C#
      - ASP.NET Web API
      - ASP.NET MVC
      -	MongoDB
      -	Redis
      - xUnit
      -	FluenAssertion
      - NSubstitute
      - Gherkin
      - SpecFlow
      - Suzianna
      - Selenium
      -	MediatR
      -	AutoMapper
      -	FluentValidation
      -	Swagger
      -	Serilog
      -	Seq
      -	[MvcPagedList.Core](https://www.nuget.org/packages/MvcPagedList.Core/)
      -	[RedisCache.Core](https://www.nuget.org/packages/RedisCache.Core/)
  * ### Front-end:
      - Blazor
        - Blazor Server
        - Cookie Authentication without ASP.NET Identity
        - Working with APIs protected by JWT
        - Comunication between components by messages
      -	.HTML
      -	CSS
      -	Java Script 
      -	JQuery
      -	Bootstrap
      -	Jquery.noty
      -	Chart.js
  * ### Patterns, Methodologies، Approaches:
      -	[Onion Architecture](https://github.com/hamed-shirbandi/TaskoMask/wiki/Architecture-Documentation)
      - Testing
         - [Unit Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Unit)
         - [Integration Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Integration)
         - [E2E Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Acceptance/Tests.Acceptance.API)
         - [UI Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Acceptance/Tests.Acceptance.UI)
         - [Acceptance Testing](https://github.com/hamed-shirbandi/TaskoMask/tree/master/Src/Tests/Acceptance)
            - Screenplay Pattern
            - Well writen tests Organized in:
                - Business Rule Layer
                - Business Flow Layer
                - Technical Layer
            - Test from API level
            - Test from UI level
         - Object Mother Pattern
         - Test Hooks
         - Test Doubles
            - Dummy
            - Stub
            - Mock
        - Teardown
            - Sandbox (for integration and acceptance tests)
        - Fixture Management
            - Fresh
            - Shared
            - Transient
            - Persistent
        - Verification
            - State
            - Output/Value
            - Interaction/Behavior
      -	DDD
        - Rich Domain Model (for core domain)
        - Anemic Domain Model (for less important subdomains)
        - Aggregate
        - Value Object
        - Domain Event
        - Domain Service
		- Always Valid Domain Model
		- Invariants
        - Specification
        - Factory Method
        - Optimistic Concurrency
        - Separate Domain Model and Data Model
      -	CQRS
        - Separate Read and Write Model
        - Separate Read Side DB and Write Side DB
      -	Event Sourcing
      -	Repository
      -	Notification
  * ### Some Technical Features:
      -	Caching Behavior using Pipeline Pattern
      -	Validation using Pipeline Pattern (Check both Fluent Validation and Data Annotation Validation)
      -	Event Storing using Pipeline Pattern
      -	Domain & Application Exception Handler
      -	InMemory Bus
      -	Cookie Authentication
      -	JWT Authentication
      -	Role Permission Base User Management without ASP.NET Identity
      -	Swagger UI with JWT Support

# Contributing
Contributions, issues, and feature requests are welcome. Feel free to check issues page if you want to contribute. Any contributions you make are greatly appreciated.
Please check the issues and [projects](https://github.com/hamed-shirbandi/TaskoMask/projects) pages before anything.
  > 1. Give a Star
  > 2. Fork the Project
  > 3. Create your Feature Branch
  > 4. Commit your Changes
  > 5. Open a Pull Request

This project exists thanks to all the people who [contribute](https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors).

<a href="https://github.com/hamed-shirbandi/TaskoMask/graphs/contributors">
  
  ![GitHub Contributors Image](https://contrib.rocks/image?repo=hamed-shirbandi/TaskoMask)
  
</a>

# Articles And Tutorials
* [Real-world open-source project based on .NET 6 with DDD, ES, CQRS concepts](https://medium.com/@hamed.shirbandi/real-world-open-source-project-based-on-ddd-es-cqrs-af261cc24353)
* [How to Blazor articles](https://medium.com/@hamed.shirbandi/how-to-blazor-articles-2bda783d9502)
     
# Supporting
We work hard to make something useful for .NET community, so please give a star ⭐ if this project helped you!
We need your support by giving a star or contributing or sharing this project with anyone who can benefit from it.

# Author & License
This project is developed by [Hamed Shirbandi](https://github.com/hamed-shirbandi) under [MIT](https://github.com/hamed-shirbandi/TaskoMask/blob/master/LICENSE) licensed.
Find Hamed around the web and feel free to ask your question.

<a href="https://www.linkedin.com/in/hamed-shirbandi"><img alt="LinkedIn" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/LinkedIn-v2.png" width="35"></a>
<a href="https://www.instagram.com/hamedshirbandi"><img alt="Instagram" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Instagram-v2.png" width="35"></a>
<a href="https://github.com/hamed-shirbandi"><img alt="GitHub" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/GitHub-v2.png" width="35"></a>
<a href="https://medium.com/@hamed.shirbandi"><img alt="Medium" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Medium-v2.png" width="35"></a>
<a href="https://www.nuget.org/profiles/hamed-shirbandi"><img alt="Nuget" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Nuget-v2.png" width="35"></a>
<a href="mailto:hamed.shirbandi@gmail.com"><img alt="Email" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Email-v2.png" width="35"></a>
<a href="https://t.me/hamed_shirbandi"><img alt="Telegram" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Telegram-v2.png" width="35"></a>
<a href="https://twitter.com/hamed_shirbandi"><img alt="Twitter" src="https://github.com/hamed-shirbandi/hamed-shirbandi/blob/main/docs/Twitter-v2.png" width="35"></a>

# Change logs
*	### Apr, 2022
    - [x] Add Unit Tests
    - [x] Add Integration Tests
    - [x] Add Acceptance Tests
    - [x] Add E2E Tests
    - [x] Add UI Tests
*	### Jan, 2022
    - [x] Full domain model refactoring by DDD concepts
    - [x] Separate Domain Model and Data Model
    - [x] Separate Read Side and Write Side Database
*	### Dec, 2021
    - [x] Upgrade to .NET 6
*	### Nov, 2021
    - [x] Start user panel with Blazor
*	### Oct, 2021
    - [x] Start admin panel with ASP.NET MVC
    - [x] Implement administration subdomain by CRUD
*	### Aug, 2021
    - [x] Remove Asp.net Identity from project
    - [x] Add cookie authentication
    - [x] Add jwt authorization
 * ### Jul, 2021
    - [x] Full refactore
 * ### Nov, 2020
    - [x] Upgrade from net 3.1 to net 5
*	### Oct, 2020
    - [x] Repository Created
  


