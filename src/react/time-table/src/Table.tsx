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
            <div className="timetable">
                <div className="timeline">
                    {this.state.timetable.map((currentClass: Class, index) => (
                        <div key={currentClass.name + index} className={`event ${currentClass.name.toLowerCase()}`}>
                            <div className="time">{currentClass.time}</div>
                            <div className="event-details">
                                <div className="event-name">{currentClass.name}</div>
                                <div className="event-duration">{currentClass.duration}</div>
                                <div className="event-room">{currentClass.room}</div>
                                <div className="event-teacher">{currentClass.teacher}</div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        );
    }
}

export default Timetable;