# 10.  Use separate database schemas

Date: 2024-03-15

## Problem

While maintaining modularity and scalability, we need to define an approach for storing and retrieving data in our application.

## Decision

It was decided to use a single relational database, postrgres, divided into separate schemas for each module. Each module's data is completely encapsulated in its own schema, preventing data sharing between modules.

## Consequences

- Each schema can be easily extracted into a separate database if needed. This allows us to scale individual schemas based on their specific requirements
- Additional maintenance, such as updating and migrating diagrams individually, can result from managing separate diagrams for each module
- Reduce the risk of future complications by isolating data within each module's schema, preventing potential data entanglement between modules