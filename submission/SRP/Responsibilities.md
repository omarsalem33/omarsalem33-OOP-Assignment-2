# Task 1.1

(SRP) is about having **one reason to change**, not one method per class.

## 1. WardBoard

**Responsibilities found**

- Store which patient is assigned to each bed.
- Calculate the clinical acuity score from heart rate and SpO2.
- Decide when a pager/code alert should be fired and store the alert log.
- Build a nurse handoff note.
- Export the ward census as CSV.

**Why this is a problem**
A clinical scoring change, a paging-policy change, a handoff-text change, or a CSV-format change would all require changing the same class. Different stakeholders and different kinds of requirements are coupled together.

## 2. CheckoutBasket

**Responsibilities found**

- Store basket lines and basket state.
- Calculate subtotal and grand total.
- Parse coupon text and calculate discounts.
- Apply gift-wrap pricing policy.
- Generate customer-facing gift-message text.
- Create a payment authorization stub.

**Why this is a problem**
Pricing rules, marketing coupon syntax, packaging fees, customer copy, and payment-gateway behavior change for different reasons. A marketing change should not force us to edit checkout math, and a gateway change should not affect the basket rules.

## 3. CourseEnrollmentDesk

**Responsibilities found**

- Manage seated students and waitlist state.
- Apply capacity and registration rules.
- Promote students from the waitlist.
- Generate welcome-packet Markdown.
- Generate tuition invoice lines and VAT formatting.

**Why this is a problem**
Enrollment operations, academy content, and finance formatting are separate concerns. A change to tuition/VAT or welcome content should not require touching seat-capacity algorithms.

## 4. GradeBook

**Responsibilities found**

- Store student scores.
- Calculate averages.
- Apply letter-grade policy.
- Apply honor-roll policy.
- Format a plain-text transcript.
- Export grade data as CSV.

**Why this is a problem**
Academic rules and document/export formats have different reasons to change. A new registrar format should not require changing grading calculations, and changing the grade bands should not require changing CSV layout.

## 5. KitchenTicket

**Responsibilities found**

- Store order items and normalize ingredient text.
- Detect allergens.
- Estimate preparation time.
- Render a thermal-printer ticket.
- Decide the expo lane hint.

**Why this is a problem**
Regulatory allergen rules, kitchen ETA heuristics, printer layout, and expo routing policy are different axes of change. Keeping them together makes independent changes risky.

## 6. LoanDesk

**Responsibilities found**

- Store loan application data.
- Calculate risk score.
- Decide eligibility.
- Determine required compliance documents.
- Generate applicant decision-letter prose.
- Export an underwriter CSV row.

**Why this is a problem**
The risk committee may change the scoring model, compliance may change the document checklist, legal/CX may change the letter text, and analytics may change the CSV schema. None of these should require modifying the others.

## 7. SubscriptionBilling

**Responsibilities found**

- Calculate subscription proration.
- Generate invoice numbers.
- Track failed payments.
- Generate dunning email text.
- Generate accounting ledger output.

**Why this is a problem**
Finance calculation, invoice numbering, collections messaging, and accounting integration are separate responsibilities. The original class even changes invoice state while composing an email, which creates a hidden side effect in a presentation operation.

## 8. SupportTicket

**Responsibilities found**

- Store ticket conversation content.
- Classify priority from free-text keywords.
- Calculate SLA deadline and breach status.
- Generate the public customer reply.
- Generate the internal escalation blurb.

**Why this is a problem**
Support playbook keywords, SLA policy, customer-facing wording, and internal escalation format can all evolve independently. The ticket entity should not own all of those policies and message formats.

## 9. AppointmentDesk

**Responsibilities found**

- Define business-hour and slot-alignment rules.
- Search for the next available slot.
- Track and book appointments.
- Generate an ICS calendar event.
- Generate an SMS reminder.

**Why this is a problem**
Clinic operating hours, scheduling behavior, calendar interoperability, and SMS copy belong to different change streams. A calendar-client formatting change should not touch appointment-hour rules.

## 10. WarehousePickList

**Responsibilities found**

- Store picking needs.
- Allocate available stock.
- Calculate a warehouse walking order.
- Generate picker instructions and shortage warnings.
- Generate WMS XML integration output.

**Why this is a problem**
Inventory allocation, warehouse-routing heuristics, handheld UX wording, and WMS integration have different owners and different reasons to change. They should not be coupled in one class.
