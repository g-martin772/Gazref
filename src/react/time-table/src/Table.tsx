import React, { Component } from 'react';
import './Table.scss'

interface Class {
    name: string;
    time: string;
    duration: string;
    room: string;
    teacher: string;
}

const classes: Class[] = [
    { name: "Math", time: "9:00am", duration: "1hr", room: "101", teacher: "Mr. Smith" },
    { name: "English", time: "10:30am", duration: "1.5hrs", room: "202", teacher: "Ms. Johnson" },
    { name: "Science", time: "1:00pm", duration: "2hrs", room: "203", teacher: "Dr. Williams" },
    { name: "History", time: "2:30pm", duration: "1.5hrs", room: "204", teacher: "Mrs. Jones" }
];

class Timetable extends Component {
    state = {
        timetable: []
    }

    componentDidMount() {
        this.setState({ timetable: classes });
    }

    render() {
        return (
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Time</th>
                        <th>Duration</th>
                        <th>Room</th>
                        <th>Teacher</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.timetable.map((currentClass: Class, index) => (
                        <tr key={currentClass.name + index} className={currentClass.name.toLowerCase()}>
                            <td>{currentClass.name}</td>
                            <td>{currentClass.time}</td>
                            <td>{currentClass.duration}</td>
                            <td>{currentClass.room}</td>
                            <td>{currentClass.teacher}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }
}

export default Timetable;
