import React, { useEffect, useState } from "react";
import axios from "axios";
import "./RubiksCube.css";

const FACES = ["Up", "Left", "Front", "Right", "Back", "Down"] as const;
type FaceName = typeof FACES[number];

const API_BASE = "https://localhost:5000/api/rubikscube";

const COLORS: Record<string, string> = {
  White: "#ffffff",
  Yellow: "#ffff00",
  Green: "#00cc00",
  Blue: "#0000ff",
  Orange: "#ff9900",
  Red: "#ff0000"
};

const FACE_LABELS: Record<FaceName, string> = {
  Front: "F",
  Right: "R",
  Up: "U",
  Back: "B",
  Left: "L",
  Down: "D",
};

export default function RubiksCube() {
  const [cube, setCube] = useState<Record<string, string[][]>>({});

  const fetchState = async () => {
    try {
      const res = await axios.get(`${API_BASE}/state`);
      setCube(res.data);
    } catch (err) {
      console.error("Failed to fetch cube state", err);
    }
  };

  const rotate = async (face: string, direction: "CW" | "CCW") => {
    await axios.post(`${API_BASE}/rotate`, { face, direction });
    fetchState();
  };

  useEffect(() => {
    fetchState();
  }, []);

  const renderFace = (face: string) => {
    const data = cube[face];
    if (!data) return <div className="face">?</div>;

    return (
      <div className="face">
        {data.map((row, rowIndex) => (
          <div key={rowIndex} className="row">
            {row.map((color, colIndex) => (
              <div
                key={colIndex}
                className="cell"
                style={{ backgroundColor: COLORS[color] || "#aaa" }}
              />
            ))}
          </div>
        ))}
      </div>
    );
  };

  return (
   <div className="cube-container">
  <div className="face-row">
    <div className="empty-space"></div>
    {renderFace("Up")}
    <div className="empty-space"></div>
    <div className="empty-space"></div>
  </div>

  <div className="face-row">
    {renderFace("Left")}
    {renderFace("Front")}
    {renderFace("Right")}
    {renderFace("Back")}
  </div>

  <div className="face-row">
    <div className="empty-space"></div>
    {renderFace("Down")}
    <div className="empty-space"></div>
    <div className="empty-space"></div>
  </div>

   <div className="controls">
        <div className="control-row">
          {["Front", "Right", "Up", "Back", "Left", "Down"].map(face => (
            <button
              key={face + "CW"}
              onClick={() => rotate(face, "CW")}
              className="btn cw"
            >
              {FACE_LABELS[face as FaceName]}
            </button>
          ))}
        </div>
        <div className="control-row">
          {["Front", "Right", "Up", "Back", "Left", "Down"].map(face => (
            <button
              key={face + "CCW"}
              onClick={() => rotate(face, "CCW")}
              className="btn ccw"
            >
              {FACE_LABELS[face as FaceName]}'
            </button>
          ))}
        </div>

    <button className="btn reset" onClick={async () => {
      await axios.post(`${API_BASE}/reset`);
      fetchState();
    }}>
      Reset
    </button>
  </div>
</div>
  );
}
