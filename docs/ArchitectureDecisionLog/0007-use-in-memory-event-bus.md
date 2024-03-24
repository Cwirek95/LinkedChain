# 7.  Use in-memory event bus

Date: 2024-03-15

## Problem

A way is needed for components to communicate and interact with each other without tight coupling.

## Decision

At this point, it does not make sense to use more advanced integration scenarios in our system than a simple publish/subscribe scenario.

## Consequences

- We need to implement Publish/Subscribe in memory
- By implementing an in-memory event bus, our components will be loosely coupled and better able to communicate and interact with each other. This will enable us to develop and deploy our system in a more scalable and flexible way