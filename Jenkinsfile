pipeline {
    agent any
    environment {
        UNITY_PATH = 'C:\\Program Files\\Unity\\Hub\\Editor\\2021.3.13f1\\Editor\\Unity.exe'
        PROJECT_PATH = "${WORKSPACE}"
        BUILD_PATH = "${WORKSPACE}/WindowsBuild"
        BUILD_TARGET = 'StandaloneWindows'
         SLACK_CHANNEL = '#jenkins-notifications'
        SLACK_CREDENTIAL_ID = 'slackWebhook'
    }
    stages {
        stage('Notify Start') {
            steps {
                slackSend(channel: "${SLACK_CHANNEL}", color: '#FFFF00', message: "Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' started. (<${env.BUILD_URL}|Open>)", tokenCredentialId: "${SLACK_CREDENTIAL_ID}")
            }
        }
        stage('Checkout') {
            steps {
                // Clone the GitHub repository
                git url: 'https://github.com/sabu-jr/Cherry-Chase-Unity-2D-Game.git', branch: 'main'
            }
        }
        stage('Build') {
            steps {
                 bat """
                "${UNITY_PATH}" -batchmode -quit -projectPath ${PROJECT_PATH} -buildTarget ${BUILD_TARGET} -executeMethod BuildScript.WindowsBuild -logFile ${WORKSPACE}/unity.log
                """
            }
        }
    }
    
    post {
        failure {
            // Archive the Unity log file in case of a failure
            archiveArtifacts artifacts: '**/unity.log', allowEmptyArchive: true
            echo 'Build failed!'
            slackSend(channel: "${SLACK_CHANNEL}", color: '#FF0000', message: "Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' failed. (<${env.BUILD_URL}|Open>)", tokenCredentialId: "${SLACK_CREDENTIAL_ID}")
        }
        success {
            // Actions to take if the build succeeds
            echo 'Build succeeded!'
            slackSend(channel: "${SLACK_CHANNEL}", color: '#00FF00', message: "Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]' succeeded. (<${env.BUILD_URL}|Open>)", tokenCredentialId: "${SLACK_CREDENTIAL_ID}")
        }
    }
}
