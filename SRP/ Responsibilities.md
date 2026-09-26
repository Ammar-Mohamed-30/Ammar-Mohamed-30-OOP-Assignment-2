# SRP Responsibilities

## 1. WardBoard

### Responsibilities

* Tracks bed assignments and patient IDs.
* Calculates patient acuity from vital signs.
* Decides when a pager alert should be generated.
* Formats nurse handoff notes.
* Exports ward census data as CSV.

### Why this violates SRP

WardBoard has multiple independent reasons to change: bed tracking, clinical scoring rules, pager policies, handoff formatting, and CSV export.

---

## 2. CheckoutBasket

### Responsibilities

* Manages basket lines, quantities, prices, and gift-wrap state.
* Parses coupon text and calculates discounts.
* Calculates subtotal and grand total.
* Generates gift-wrap/customer-facing messages.
* Creates payment authorization codes.

### Why this violates SRP

The class mixes basket management, coupon rules, pricing, customer-facing text, and payment authorization, each of which can change independently.

---

## 3. SupportTicket

### Responsibilities

* Stores ticket information and customer messages.
* Determines ticket priority from subject and body text.
* Calculates SLA deadlines and checks SLA breaches.
* Generates public replies and internal escalation messages.

### Why this violates SRP

Ticket data, priority rules, SLA policies, and communication templates are separate concerns with different reasons to change.

---

## 4. LoanDesk

### Responsibilities

* Stores loan application data.
* Calculates risk and determines eligibility.
* Determines required compliance documents.
* Generates approval or rejection letters.
* Exports application data as a CSV row.

### Why this violates SRP

The class combines applicant data, underwriting rules, compliance rules, communication formatting, and analytics export.

---

## 5. CourseEnrollmentDesk

### Responsibilities

* Manages course registration and available seats.
* Manages the waitlist and promotes students from it.
* Generates welcome packet content.
* Generates tuition invoice lines and calculates VAT.

### Why this violates SRP

Enrollment, waitlist operations, welcome content, and financial formatting are separate responsibilities that can change independently.

---

## 6. KitchenTicket

### Responsibilities

* Manages kitchen order items and their preparation data.
* Detects allergens from ingredients.
* Calculates estimated preparation time.
* Generates the printed kitchen ticket and determines the expo lane.

### Why this violates SRP

Order management, allergen rules, kitchen timing, and printer/presentation concerns have different reasons to change.

---

## 7. SubscriptionBilling

### Responsibilities

* Stores subscription billing data and failed payment state.
* Calculates prorated subscription charges.
* Generates invoice numbers.
* Generates payment-failure/dunning emails.
* Exports accounting ledger data.

### Why this violates SRP

Billing calculations, invoice numbering, customer communication, and accounting export are independent concerns and can change separately.

---

## 8. WarehousePickList

### Responsibilities

* Stores warehouse picking requirements.
* Allocates available stock to requested quantities.
* Determines the walking order through the warehouse.
* Generates picker instructions.
* Generates WMS XML integration data.

### Why this violates SRP

Inventory allocation, warehouse routing, picker instructions, and WMS integration have different reasons to change.

---

## 9. GradeBook

### Responsibilities

* Records and stores student scores.
* Calculates student averages.
* Applies academic grading and honor-roll policies.
* Generates transcript and CSV output.

### Why this violates SRP

Score storage, grade calculations, academic policies, and output formats are separate responsibilities that can change independently.

---

## 10. AppointmentDesk

### Responsibilities

* Manages booked appointment slots.
* Determines business-hour availability.
* Searches for the next available appointment slot.
* Generates ICS calendar data.
* Generates SMS reminder messages.

### Why this violates SRP

Booking, business-hour rules, scheduling logic, calendar serialization, and messaging are separate concerns with different reasons to change.
