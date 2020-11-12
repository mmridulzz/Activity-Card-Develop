import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/teacher";
import { Table} from 'antd';
import TeacherForm from "./TeacherForm";
import { Button } from 'antd';
import * as actions1 from "../actions/user";
import * as actions2 from "../actions/email";
import * as actions3 from "../actions/notification";
import { notification } from 'antd';
import { Collapse } from 'antd';
import { Skeleton } from 'antd';
import {
    DeleteOutlined, MailOutlined, CheckCircleTwoTone

} from '@ant-design/icons';

const { Panel } = Collapse;
const Teacher = ({ ...props }) => {
    
    const [currentId, setCurrentId] = useState(0)
    const columns = [
        {
            title: 'Name',
            dataIndex: 'user',
            key: 'user',
            render: (record) => (
                <p>{record?.firstName}</p>
            )
        },
        {
            title: 'Email',
            dataIndex: 'email',
            key: 'email',
            render: (text) => (
                <p>{text}</p>
            )
        },
        {
            title: 'Action',
            dataIndex: 'user',
            key: 'user',
            render: (record) => <Button icon={<DeleteOutlined />} onClick={() => onDelete(record.id)}></Button>
        },
        {
            title: 'Action',
            dataIndex: 'user',
            key: 'user',
            render:
                (record) => {
                    if (record?.notification == "yes") {
                        return <CheckCircleTwoTone twoToneColor="#52c41a" />
                    }
                    else {
                        return (< Button icon={< MailOutlined />} onClick={() => sendMail(record?.id, record?.username)}></Button >)
                       
                    }
                }
        }
        
    ];
   
    useEffect(() => {
        console.log("teacher call")
        props.fetchAllTeacher()
        console.log(props.teacherList)
        props.fetchAllTeacher()
    }, [currentId])//componentDidMount
    if (props.teacherList?.tId) {
        console.log("true")
        return <p>Loading...</p>
    }
    if (props.teacherList?.user) {
        console.log("true")
        return <p>Loading...</p>
    }
    if (props.teacherList?.teacherclasses) {
        console.log("true")
        return <p>Loading...</p>
    }
    
    if (props.Loading == true) { return <Skeleton active /> }
    const sendMail = (id, username) => {
        const val = { "Id": id, "username": username }
        console.log("this is it", val)
        const args = {
            message: 'Update Notification ',
            description:
                'Successfully Updated',
            duration: 0,
        };
        const onSuccess = () => {
            notification.open(args);
        }
        const onSuccess1 = () => {
            console.log("notification added");
        }
        props.createEmail(val, onSuccess)
        setCurrentId(id)
        const val1 = {
            "message": "email sent to " + username , "Readstatus": "no", "NUserId": localStorage.getItem('userid')
        }

        props.createNotification(val1, onSuccess1)
    }
    const onDelete = id => {
        setCurrentId(id)
        const args = {
            message: 'Update Notification ',
            description:
                'Successfully Updated',
            duration: 0,
        };
        const onSuccess = () => {
            notification.open(args);
        }
        const onSuccess1 = () => {
           console.log("notofication added");
        }
        if (window.confirm('Are you sure to delete this record?')) {
            props.deleteUser(id, () => onSuccess())
            const val1 = {
                "message": "teacher deleted with id  " + id, "Readstatus": "no", "NUserId": localStorage.getItem('userid')
            }

            props.createNotification(val1, onSuccess1)
        }
    }
  
   
   
    return (
        <div className="site-layout-background" style={{ padding: 24, textAlign: 'center' }}>
            <Collapse defaultActiveKey={['1']}>
                <Panel header="Add Teacher" key="1">
                    <TeacherForm  {...({ currentId, setCurrentId })} />
                </Panel>
                <Panel header="Existing Teachers" key="2">
                    
                    <Table dataSource={props.teacherList} columns={columns} />     
                        
                </Panel>
            </Collapse>
            </div>
            
        
    );
}

const mapStateToProps = state => ({
    teacherList: state.teacher.list,
    userList: state.user.list,
    Loading:state.teacher.loading,
    emailList:state.email.list
})

const mapActionToProps = {
    
    fetchAllTeacher: actions.fetchAll,
    deleteUser: actions1.Delete,
    createEmail: actions2.create,
    createNotification: actions3.create
}

export default connect(mapStateToProps, mapActionToProps)(Teacher);