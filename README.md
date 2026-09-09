# PROG6221_ICE3_ST10460756

# PROG6221_ICE3_ST10460756 - Cybersecurity Tip Manager

## Project Purpose
A console application that stores, filters, and displays cybersecurity tips using generic collections, delegates, events, and lambda expressions.

## Features
- Stores cybersecurity tips in a generic List<CyberTip>
- Filters tips by category using lambda expressions
- Uses delegates for flexible tip formatting
- Implements events to notify when tips are displayed
- Interactive loop allowing repeated filtering

## How to Run
1. Open in Visual Studio 2022
2. Build (Ctrl+Shift+B)
3. Run (F5)
4. Follow on-screen prompts to filter tips by category
5. Type 'exit' to quit

## Project Structure
- **CyberTip.cs**: Represents a tip with Category and Message properties
- **TipManager.cs**: Manages the collection, filtering, events, and delegates
- **Program.cs**: Main application flow and user interaction

## Explanation of Concepts

### List<CyberTip> vs TipFormatter Delegate

**List<CyberTip>** is a generic collection that stores multiple CyberTip objects. It provides:
- Type safety (only CyberTip objects can be stored)
- Methods for adding, removing, and searching
- Iteration capabilities
- Memory management

**TipFormatter** is a delegate (function pointer) that:
- Defines a method signature for formatting tips
- Allows different formatting strategies to be passed as parameters
- Provides flexibility in how tips are displayed
- Enables lambda expressions for inline formatting

### TipDisplayed Event
The TipDisplayed event is raised when:
1. A tip is successfully displayed to the user
2. The `OnTipDisplayed` method is called after each tip is shown
3. Subscribers (like Program.cs) receive the event and display a confirmation message

## Benefits of This Design
- **Separation of Concerns**: Each class has a specific responsibility
- **Flexibility**: Delegates allow different formatting options
- **Extensibility**: Events allow additional actions when tips are displayed
- **Type Safety**: Generic collections ensure only correct types are used

## GitHub Commits
1. Initial project setup with CyberTip and TipManager classes
2. Implementation of generic collection and lambda filtering
3. Adding delegate, event handling, and README

## Author
Student: ST10460756
Module: PROG6221 - Programming 2A
Lecturer: Andiswa Phewa
