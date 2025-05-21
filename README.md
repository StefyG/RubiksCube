# Rubik's Cube Challenge

This project implements a fully functional Rubik's Cube with visualization, face rotations, reset functionality, and integration between an ASP.NET Core Web API and a React UI.

---

## 🧩 Project Structure

```
RubiksCube.sln (solution)
├── RubiksCubeChallenge/            # Core cube logic
│   ├── Enums/                      # Color, Face, Rotation
│   ├── Helpers/                    # FaceMatrixHelper
│   ├── Strategy/                   # IFaceRotationStrategy + rotation classes
│   ├── RubiksCube.cs               # Cube model
│   └── Program.cs
│
├── RubiksCubeChallenge.API/       # ASP.NET Core Web API
│   ├── Controllers/                # RubiksCubeController
│   ├── Interfaces/                 # IRubiksCubeService
│   ├── Models/                     # RotationRequest DTO
│   ├── Services/                   # RubiksCubeService
│   └── Program.cs
│
├── RubiksCubeChallenge.Tests/     # Unit tests
│   ├── Helpers/                    # CubeAssertions
│   ├── RubiksCubeTests.cs         # Cube logic tests
│   └── FaceMatrixTests.cs         # Face rotation tests
│
├── rubikscube-frontend/           # React TypeScript UI
│   ├── src/components/RubiksCube.tsx
│   └── public/index.html, index.css
```

---

## ⚙️ Requirements

### Backend:
- .NET 8 SDK

### Frontend:
- Node.js (LTS recommended)

---

## ▶️ How to Run the Project

### 🖥️ 1. API (ASP.NET Core)

```bash
cd RubiksCubeChallenge.API

dotnet run
```

🔗 Default URL: `https://localhost:5000`

### 🌐 2. React App

```bash
cd rubikscube-frontend

npm install
npm start
```

🔗 Default URL: `http://localhost:3000`

📌 The React frontend communicates with the API at `https://localhost:5000`

---

## 📡 API Endpoints

| Method | Path                          | Description                         |
|--------|-------------------------------|-------------------------------------|
| GET    | `/api/rubikscube/state`       | Returns current cube state          |
| POST   | `/api/rubikscube/rotate`      | Rotates a face of the cube          |
| POST   | `/api/rubikscube/reset`       | Resets the cube to solved state     |


---

## 🧪 Testing

```bash
cd RubiksCubeChallenge.Tests

dotnet test
```

Test coverage includes:
- Face rotations
- Cube reversion after multiple moves
- Solved state validation

---

## 🧠 Technologies Used

- **C# .NET 8 – Core logic and Web API
- **React + TypeScript** – UI rendering and interaction
- **Axios** – HTTP communication
- **xUnit** – Unit testing
- **CSS** – Cube layout and style

---

## 💡 Notes

- Rotations are implemented using the **Strategy Pattern**
- Backend uses **Dependency Injection** for service separation
- The cube layout is visualized as a 2D net (U above F, D below F, L-F-R-B horizontally)
- Supports all 12 face rotations and a reset button

---

## ✅ Final Remarks

The project follows clean architecture principles, uses modern technologies, and is fully functional and ready for demonstration or future extension.


