import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/teacherclasses";
import * as actions1 from "../actions/classes";
import * as actions2 from "../actions/notification";
import Classesform from "./Classesform";
import { notification } from 'antd';
import { Card, Tag } from 'antd';
import { Skeleton } from 'antd';
import { store } from "../actions/store";
import { Provider } from "react-redux";
import {
    Row,
    Col,
    Button,
} from 'antd';
import { DeleteOutlined} from '@ant-design/icons';

const Classes = ({ ...props }) => {
    const [currentId,setcurrentId]=useState(0)
    const classnamearray=[]
    
    useEffect(() => {
        console.log("teacherclasses call")
        props.fetchAllTeacherClasses()
        console.log("teacherclasses",props.Loading)
        return async function cleanup() {
            console.log("clearing")
            await props.clearClasses()
            console.log("cleared one", props.teacherclassesList)
        };
    }, [currentId])
    
    if (!Array.isArray(props.teacherclassesList)) {
        return <p>Loading</p>
    }
    if ((props.teacherclassesList?.classInfo)) {
        return <p>Loading</p>
    }
    if ((props.teacherclassesList?.teacher)) {
        return <p>Loading</p>
    }
    if (props.Loading == true) { return <Skeleton active />}
    function checkForDuplicates(cId) {
        var newArr1 = []
       
        newArr1 = props.teacherclassesList.filter(city => city?.cId == cId)
        
       
        return newArr1
    }
    const onDelete = (id)=>
{
        console.log(id)
        const args = {
            message: 'Update Notification ',
            description:
                'Successfully Updated',
            duration: 0,
        };
        const onSuccess = () => {
            notification.open(args);
            setcurrentId(currentId => currentId + 1)
        }
        const onSuccess1 = () => {
            console.log("notification added")
        }
        if (window.confirm('Are you sure to delete this record?')) {
            props.deleteClasses(id, () => onSuccess())
            const val1 = { "message": "Class with id "+ id+" deleted", "Readstatus": "no", "NUserId": localStorage.getItem('userid') }
            props.createNotification(val1, onSuccess1)
        }
    }
   
    return (
        
            <div style={{ textAlign: "left" }} style={{ backgroundColor: 'white' }}>
                <Provider store={store}>
                    <Classesform {...({ currentId, setcurrentId })} />
                 </Provider>
            <Row gutter={16}>
                <Col span={8}>
                    {  
                        props.teacherclassesList.map((record, index) => {
                            return (
                                !(classnamearray.includes(record?.cId)) &&
                                <Card key={record?.cId} title={record.classInfo?.className} bordered={false} extra={<Button icon={<DeleteOutlined />} onClick={() => onDelete(record.cId)} ></Button>}>
                                    {
                                        console.log(classnamearray.push(record.cId))
                                    }
                                    <div>
                                        <Tag color="#87d068">{record.classInfo?.schoolYear?.year}</Tag>
                                        </div>
                                    <div>
                                        {
                                            checkForDuplicates(record?.cId).map((teachers, idx) => {
                                                return (<div><Tag key={idx } color="#f50">{teachers.teacher?.email}</Tag></div>)
                                            })} 
                                        
                                        </div>
                                </Card>
                            )
                        })}
                </Col>
                </Row>
        </div>
        
    );
}


const mapStateToProps = state => ({
    teacherclassesList: state.teacherclasses.list,
    classList: state.classes.list,
    Loading: state.teacherclasses.loading,
})

const mapActionToProps = {
    fetchAllTeacherClasses: actions.fetchAll,
    deleteClasses: actions1.Delete,
    clearClasses: actions.cleardata,
    createNotification: actions2.create
}

export default connect(mapStateToProps, mapActionToProps)(Classes);