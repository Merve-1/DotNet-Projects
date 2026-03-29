# 🛒 Online Store Order Processing System

## 📌 Overview

A backend system for an online store called **ShopMaster**.

The goal is to design a flexible and extensible system using **delegates** so that new behaviors (filters, reports, transformations) can be added without modifying existing code.

---

## 🎯 Objectives

* Implement flexible product search functionality
* Generate customizable reports
* Transform product data dynamically
* Filter products based on conditions
* Apply built-in delegates (`Func`, `Action`, `Predicate`) effectively

---

## 🧱 Project Structure

### 1. Product Model

Represents a product in the store.

Properties:

* `Id` → Unique identifier
* `Name` → Product name
* `Category` → Product category (Electronics, Clothing, Food, Books)
* `Price` → Product price
* `Stock` → Available quantity

---

### 2. Product Catalog

A predefined list of products used for testing all features.

---

## ⚙️ Features Implemented

---

### 🔍 Task 01: Smart Product Search

#### Description

A flexible search system that allows filtering products using any condition without modifying the method.

#### Implementation

* Method: `SearchProducts`
* Delegate used: `Func<Product, bool>`

#### Example Filters:

* Electronics products
* Products under $50
* Products in stock
* Clothing under $100

---

### 📊 Task 03: Custom Report Generator

---

#### 🖨️ 3.1 Print Reports

##### Description

Prints product data in different formats depending on the provided logic.

##### Method:

* `PrintReport`
* Delegate used: `Action<Product>`

##### Scenarios:

* Short Report → `Name - Price`
* Detailed Report → `[Category] Name | Price | Stock`

---

#### 🔄 3.2 Transform Products

##### Description

Transforms product data into another format.

##### Method:

* `TransformProducts`
* Delegate used: `Func<Product, TResult>`

##### Scenarios:

* Summary List → `Laptop ($1200)`
* Price Labels → `Expensive!` or `Affordable`

---

#### ⚠️ 3.3 Filter Products

##### Description

Filters products based on a condition.

##### Method:

* `FilterProducts`
* Delegate used: `Predicate<Product>`

##### Scenario:

* Low Stock Alert → Products with stock less than 20

---
