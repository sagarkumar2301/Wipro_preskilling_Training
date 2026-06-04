const express = require("express");
const cors = require("cors");

const app = express();

app.use(cors());

app.get("/", (req, res) => {
    res.send("Backend is running on Azure");
});

app.get("/api/message", (req, res) => {
    res.json({
        message: "Hello from Azure"
    });
});

const PORT = process.env.PORT || 5000;

app.listen(PORT, () => {
    console.log('Server running on port ${PORT}');
});