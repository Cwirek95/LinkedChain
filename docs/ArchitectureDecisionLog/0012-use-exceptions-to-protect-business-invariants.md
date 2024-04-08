# 12.  Use exceptions to protect business invariants

Date: 2024-04-08

## Problem

Aggregators should check business invariants. If the invariant is incorrect, it should stop processing and return the error to the client.

## Decision

Despite the likely performance cost problems of throwing an exception, this seems to be the best and simplest solution.

## Consequences

- We will need to create different business exceptions for each business rule
- We will not have a lot of if/else statements in Entities/Value Objects to check method results
- We need to add special exception class to separate business rules validation exceptions from other exceptions