# Description
The wallet application is an application which allows users to track their expenses.
# Business
1. The application should be able to authenticate different users.
2. The application should contain a dashboard where different data is aggregated and displayed to the user
3. The user should be able to add multiple accounts which can hold different records either by integrating with a bank 
account, importing from an excel/csv or manually adding expenses.
4. The application should contain a monthly, yearly and lifetime subscription fee based on which the application will 
give access to certain features to the user.
5. The user should be able to see its records in a easy to understand graph and to be able to filter those (statistics)
6. The user should be allowed to add personal groupings to different expenses and also to be able to manage its own 
settings.

# Architecture
The application should be built for world wide users meaning it has a large base of possible users. This means that it 
must have the ability to deploy only parts of the application.

The chosen architecture has as its base microservice but each microservice implements a different architecture by itself.

# Deployment
Deployment will be realised through Azure Pipelines or Github Actions with the help of Docker & Kubernetes where 
usually a microservice is a docker container.

# Future enhancements
The application could benefit in the future from enhancements like:
1. Adding integration with other subscription based services so that you could manage all of them within the application.
2. Third party access to your finance for example your financial advisor.
3. Debt strategies and financial help directly from the application.