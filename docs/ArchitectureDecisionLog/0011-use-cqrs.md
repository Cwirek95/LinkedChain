# 11.  Use CQRS architectural style

Date: 2024-03-25

## Problem

The application will handle 2 types of requests. For reading, we will need a relational data model to return data in tabular/flat form (tables, lists, dictionaries).
For writing, on the other hand, you will need a graph of objects to do more complex work, such as validations or checking business rules.

## Decision

The CQRS architectural pattern is applied to each business module. Each module will have a separate read and write model.

## Consequences

- Commands and queries will be processed in various ways
- The principle of single responsibility will be followed
- Additional layer and reduced complexity
- MediatR introduces some overhead to performance, but it is an acceptable trade-off.