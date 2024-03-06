# 3.  Use modular monolith architecture for the backend part of the application

Date: 2024-03-01

## Problem

I need to take an efficient approach to implementing our solution while maintaining modularity and scalability.

## Decision

I decided to build the business part of the application using modular monolithic architecture and Domain Driven Design tactical patterns.

## Consequences

- Each module encapsulates its processes, promoting problem separation
- This approach increases the flexibility of our monolithic application, making it easier to maintain
- Domain Driven Design tactical patterns are used to implement each of the modules